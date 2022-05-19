using System;
using System.Collections.Generic;
using Core.Entities;
using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            var result = new SuccessResult();
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }

            return result;
        }

        public static List<IResult> RunMultiple(params IResult[] logics)
        {
            var resultList = new List<IResult>();
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    resultList.Add(logic);
                }
            }

            return resultList;
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