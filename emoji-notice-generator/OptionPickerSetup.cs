using System;

namespace emoji_notice_generator
{
    public class OptionPickerSetup
    {
        public OptionPicker OptionPicker;

        public OptionPickerSetup(string[] args)
        {
            OptionPicker op = new OptionPicker(
                string.Join(" ", args)
            );

            this.OptionPicker = op
                .AddCondition(_ => _.StartsWith("-"))
                .AddCondition(_ => _.StartsWith("--"));
        }

        public bool HasWriteOption()
        {
            string target = "write";

            string t1 = $"--{target}";
            string t2 = $"-{target[0]}";

            return
                this.OptionPicker.Has(t1) ||
                this.OptionPicker.Has(t2);
        }
    }
}