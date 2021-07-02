using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace emoji_notice_generator
{
    class Generator
    {
        static void Main(string[] args)
        {
            OptionPickerSetup ops = new OptionPickerSetup(args);

            List<string> argv = ops.OptionPicker.GetArgv();

            string targetPath = ".";

            // TODO: input path from argv
            // if (argv.Count >= 1)
            // {
            //     targetPath = argv[0];
            // }

            string[] res = Readdir.readdir(targetPath);

            bool mayIexport = ops.HasWriteOption();

            string result = string.Join("\n", LINQutils.Map(
                res,
                (fname, index) => $"{index}: :{fname}: `:{fname}:`")
            );

            Console.WriteLine(result);

            string resultFilePath = "./result.txt";

            if (mayIexport)
            {
                File.WriteAllText(resultFilePath, result);
            }
        }
    }
}