using System.Collections.Generic;
using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }

            return new SuccesResult();
        }
        public static List<IResult> RunMultiple(params IResult[] logics)
        {
            List<IResult> resultList= new List<IResult>();
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    resultList.Add(logic);
                }
            }
            if (resultList.Count>0)
            {
                return resultList;
            }

            return null!;
        }

        // public static IResult RunMultiple(params IResult[] logics)
        // {
        //     string message = null;
        //     byte errorCount = 0;
        //     List<IResult> logicsReturn;
        //     for (int i = 0; i < logics.Length; i++)
        //     {
        //         if (!logics[i].Success)
        //         {
        //             logicsReturn.errorCount++;
        //             if (errorCount > 1)
        //             {
        //                 message += logics[i].Message + "/n";
        //             }
        //             else
        //             {
        //                 message += logics[i].Message;
        //             }
        //         }
        //     }
        //
        //     if (errorCount == 1)
        //     {
        //     }
        //
        //     return null;
        // }
    }
}