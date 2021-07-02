using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Convert;

namespace emoji_notice_generator
{
    public class OptionPicker
    {
        // original
        public readonly string OriginalString;

        // caches
        private List<string> Argv;
        private List<string> Options;

        // getters
        public List<string> GetArgv()
        {
            return this.ev().Argv;
        }

        public List<string> GetOptions()
        {
            return this.ev().Options;
        }

        // just split(/\s+/)
        private List<string> RawChunks;

        // condition lists
        public List<Condition> Conditions;

        public OptionPicker AddCondition(Condition cond)
        {
            // guarantee immutable
            OptionPicker newOP = Copy();
            newOP.Conditions.Add(cond);
            return newOP;
        }

        // constructor
        public OptionPicker(
            string str
        ) {
            this.OriginalString = str;

            string[] chunks = Regex.Split(str, "\\s+");

            this.RawChunks = chunks.ToList();
            this.Conditions = new List<Condition>();
        }

        // clone self
        public OptionPicker Copy() {
            OptionPicker newOP = new OptionPicker(this.OriginalString);

            newOP.Conditions = this.Conditions;

            return newOP;
        }

        // indicates this OptionPicker has provided option
        public bool Has(string targetOption)
        {
            return this
                .GetOptions()
                .IndexOf(targetOption) != -1;
        }

        public OptionPicker ev()
        {
            List<string> filtered = new List<string>();
            List<string> rejected = new List<string>();

            foreach (string arg in this.RawChunks)
            {
                if (Conditions.Any(cond => cond(arg)))
                {
                    filtered.Add(arg);
                }
                else
                {
                    rejected.Add(arg);
                }
            }

            OptionPicker newOP = Copy();

            newOP.Argv = rejected;
            newOP.Options = filtered;

            return newOP;
        }
    }
}