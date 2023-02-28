using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_1A2B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int[] Ans = new int[4] ;
            for(int i = 0; i < 4; i++)
            {
                Ans[i] = r.Next(10);
                while (Ans[0] == Ans[1] )
                {
                    Ans[1] = r.Next(10);
                }
                while(Ans[0] == Ans[2] || Ans[1] == Ans[2])
                {
                    Ans[2] = r.Next(10);
                }
                while (Ans[0] == Ans[3] || Ans[1] == Ans[3] || Ans[2] == Ans[3])
                {
                    Ans[3] = r.Next(10);
                }
                Console.Write(Ans[i]);
            }

            var ans = Ans.ToList();
            do
            {
                Console.WriteLine("歡迎來到 1A2B 猜數字的遊戲～");
                Console.WriteLine("------");
                Console.WriteLine("請輸入 4 個數字：");
                string input = Console.ReadLine();

                var indivual = int.Parse(input) % 10;
                var ten = (int.Parse(input) % 100) / 10;
                var hundreds = (int.Parse(input) / 100) % 10;
                var thousands = int.Parse(input) / 1000;

                int[] InputAns = new int[4];

                InputAns[0] = thousands;
                InputAns[1] = hundreds;
                InputAns[2] = ten;     
                InputAns[3] = indivual;

                var inputans = InputAns.ToList();

                var Comparison = Ans.Intersect(InputAns); 
                int A = 0, B = 0;
                foreach (var item in Comparison )
                {
                    if (ans.IndexOf(item) == inputans.IndexOf(item))
                    {
                        A++;
                    }
                    else
                    {
                        B++;
                    }
                }

                Console.WriteLine($"判定結果是{A}A{B}B");
                if (A == 4 )
                {
                    Console.WriteLine("恭喜你！猜對了！！\r\n");
                    Console.WriteLine("------");
                    Console.WriteLine("你要繼續玩嗎？(y/n): ");
                    string Final = Console.ReadLine();
                    if(Final == "n")
                    {
                        break;
                    }
                }
            } while(true);
            
        }
    }
}
