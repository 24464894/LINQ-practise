using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace LINQ_practise_main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<Product> content = System.IO.File.ReadAllLines(@"C:\Users\smpss\Desktop\product.csv", Encoding.Default)
                .Select(line => new Product(line) ).Skip(1).ToList();

            
            /*string[] OTC_Output = File.ReadAllLines(@"C:\Users\alice\Desktop\product.csv");

            foreach (string line in OTC_Output)
            {
                Console.Write(line.Split(',')[1,7]);
                Console.WriteLine(line.Split(',')[4]);
            }*/
            do
            {
                
                int CountPage = 0 ;

                do
                {
                    //Console.Clear();
                    Console.WriteLine("上一頁 P 下一頁 N 確認 Y (沒有顯示請按_N_) ");
                    string Page = Console.ReadLine();

                    if (Convert.ToChar(Page) == 'N')
                    {
                        CountPage++;
                        if (CountPage == 5)
                        {
                            CountPage--;
                        }
                    }
                    if (Convert.ToChar(Page) == 'P')
                    {
                        CountPage--;
                        if (CountPage == 0 || CountPage == -1)
                        {
                            CountPage++;
                        }
                    }
                    if (Convert.ToChar(Page) == 'Y')
                    {
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine($"第{CountPage}頁");
                    switch (CountPage)
                    {
                        case 1:
                            Console.WriteLine("1. 計算所有商品的總價格\r\n2. 計算所有商品的平均價格\r\n3. 計算商品的總數量\r\n4. 計算商品的平均數量\r\n");
                            break;
                        case 2:
                            Console.WriteLine("5. 找出哪一項商品最貴\r\n6. 找出哪一項商品最便宜\r\n7. 計算產品類別為 3C 的商品總價\r\n8. 計算產品類別為飲料及食品的商品總價\r\n");
                            break;
                        case 3:
                            Console.WriteLine("9. 找出所有商品類別為食品，而且商品數量大於 100 的商品\r\n10. 找出各個商品類別底下有哪些商品的價格是大於 1000 的商品\r\n11. 各個商品類別底下有哪些商品的價格是大於 1000 的商品計算該類別底下所有商品的平均價格\r\n12. 依照商品價格由高到低排序\r\n");
                            break;
                        case 4:
                            Console.WriteLine("13. 依照商品數量由低到高排序\r\n14. 找出各商品類別底下，最貴的商品\r\n15. 找出各商品類別底下，最便宜的商品\r\n16. 找出價格小於等於 10000 的商品\r\n");
                            break;
                           
                    }
                    
                } while (true); 
                    /*switch (int.Parse(pageInput))
                    {
                        case 1:
                            Console.WriteLine("第一頁:\r\n1. 計算所有商品的總價格\r\n2. 計算所有商品的平均價格\r\n3. 計算商品的總數量\r\n4. 計算商品的平均數量\r\n");
                            break;
                        case 2:
                            Console.WriteLine("第二頁:\r\n5. 找出哪一項商品最貴\r\n6. 找出哪一項商品最便宜\r\n7. 計算產品類別為 3C 的商品總價\r\n8. 計算產品類別為飲料及食品的商品總價\r\n");
                            break;
                        case 3:
                            Console.WriteLine("第三頁:\r\n9. 找出所有商品類別為食品，而且商品數量大於 100 的商品\r\n10. 找出各個商品類別底下有哪些商品的價格是大於 1000 的商品\r\n11. 各個商品類別底下有哪些商品的價格是大於 1000 的商品計算該類別底下所有商品的平均價格\r\n12. 依照商品價格由高到低排序\r\n");
                            break;
                        case 4:
                            Console.WriteLine("第四頁:\r\n13. 依照商品數量由低到高排序\r\n14. 找出各商品類別底下，最貴的商品\r\n15. 找出各商品類別底下，最便宜的商品\r\n16. 找出價格小於等於 10000 的商品\r\n");
                            break;
                    }*/
                Console.WriteLine("輸入你想要運作的功能(數字編號)");
                string input = Console.ReadLine();
                
                switch (int.Parse(input))
                {
                    case 1:
                        decimal PriceTotal = content.Sum(x => decimal.Parse(x.Price));
                        Console.WriteLine($"所有商品的總價格:{PriceTotal}元");
                        break;
                    case 2:
                        decimal PriceAvg = content.Average(x => decimal.Parse(x.Price));
                        Console.WriteLine($"所有商品的平均價格:{PriceAvg}元");
                        break;
                    case 3:
                        int ProductDescription_Total = content.Sum(x => int.Parse(x.ProductDescription));
                        Console.WriteLine($"商品的總數量:{ProductDescription_Total}個");
                        break;
                    case 4:
                        decimal ProductDescription_Avg = content.Average(x => decimal.Parse(x.ProductDescription));
                        Console.WriteLine($"商品的平均數量:{ProductDescription_Avg}元");
                        break;
                    case 5:
                        decimal PriceMax = content.Max(x => decimal.Parse(x.Price));
                        var PriceMaxProduct = content.Where(x => decimal.Parse(x.Price) == PriceMax);
                        foreach (var product in PriceMaxProduct)
                        {
                            Console.WriteLine($"商品最貴:{product.ProductName}");
                        }
                        break;

                    case 6:
                        var PriceMin = content.Min(x => decimal.Parse(x.Price));
                        var PriceMinProduct = content.Where(x => decimal.Parse(x.Price) == PriceMin);
                        foreach (var product in PriceMinProduct)
                        {
                            Console.WriteLine($"商品最便宜:{product.ProductName}");
                        }
                        break;

                    case 7:
                        var ElectronicTotal = content.Where((x) => x.CommodityCategory == "3C").Sum((x) => decimal.Parse(x.Price));
                        Console.WriteLine($"產品類別為 3C 的商品總價:{ElectronicTotal}元");
                        break;
                    case 8:
                        var BeverageAndFood = content.Where((x) => x.CommodityCategory == "飲料" || x.CommodityCategory == "食品").Sum((x) => decimal.Parse(x.Price));
                        Console.WriteLine($"產品類別為飲料及食品的商品價格:{BeverageAndFood}元");
                        break;
                    case 9:
                        var FoodItemsMoreThan100 = content.Where((x) => x.CommodityCategory == "食品" && int.Parse(x.ProductDescription) > 100);
                        foreach (var product in FoodItemsMoreThan100)
                        {
                            Console.WriteLine($"所有商品類別為食品，而且商品數量大於 100 的商品:{product.ProductName}");
                        }
                        break;
                    case 10:
                        var EachProductCategoryPriceGreaterThan1000 = content.Where((x) => decimal.Parse(x.Price) > 1000);
                        Console.WriteLine($"各個商品類別底下有哪些商品的價格是大於 1000 的商品:");
                        foreach (var product in EachProductCategoryPriceGreaterThan1000)
                        {
                            Console.WriteLine($"商品類別:{product.CommodityCategory}. 商品:{product.ProductName}.");
                        }
                        break;

                    case 11:
                        var EachProductCategoryPriceGreaterThan1000Avg = content.Where((x) => decimal.Parse(x.Price) > 1000).Average((x) => decimal.Parse(x.Price));
                        Console.WriteLine($"各個商品類別底下有哪些商品的價格是大於 1000 的商品計算該類別底下所有商品的平均價格:{EachProductCategoryPriceGreaterThan1000Avg}.");
                        break;

                    case 12:
                        var SortHighToLow = content.OrderByDescending((x) => decimal.Parse(x.Price));
                        Console.WriteLine("依照商品價格由高到低排序:");
                        foreach (var product in SortHighToLow)
                        {
                            Console.WriteLine($"{product.ProductName}");
                        }
                        break;
                    case 13:

                        var LowToHighSort = content.OrderBy(x => decimal.Parse(x.ProductDescription));
                        Console.WriteLine("依照商品數量由低到高排序:");
                        foreach (var product in LowToHighSort)
                        {
                            Console.WriteLine($"{product.ProductName}");
                        }
                        break;
                    case 14:
                        var ElectronicPriceMax = content.Where((x) => x.CommodityCategory == "3C").Max(x => decimal.Parse(x.Price));
                        var ElectronicPriceMaxProduct = content.Where((x) => decimal.Parse(x.Price) == ElectronicPriceMax);
                        foreach (var product in ElectronicPriceMaxProduct)
                        {
                            Console.WriteLine($"3C最貴的商品:{product.ProductName}");
                        }
                        var FoodPriceMax = content.Where((x) => x.CommodityCategory == "食品").Max(x => decimal.Parse(x.Price));
                        var FoodPriceMaxProduct = content.Where((x) => decimal.Parse(x.Price) == FoodPriceMax);
                        foreach (var product in FoodPriceMaxProduct)
                        {
                            Console.WriteLine($"食品最貴的商品:{product.ProductName}");
                        }
                        var BeveragePriceMax = content.Where((x) => x.CommodityCategory == "飲料").Max(x => decimal.Parse(x.Price));
                        var BeveragePriceMaxProduct = content.Where((x) => decimal.Parse(x.Price) == BeveragePriceMax);
                        foreach (var product in BeveragePriceMaxProduct)
                        {
                            Console.WriteLine($"飲料最貴的商品:{product.ProductName}");
                        }
                        break;
               
                     case 15:
                        var ElectronicPriceMin = content.Where((x) => x.CommodityCategory == "3C").Min(x => decimal.Parse(x.Price));
                        var ElectronicPriceMinProduct = content.Where((x) => decimal.Parse(x.Price) == ElectronicPriceMin);
                        foreach (var product in ElectronicPriceMinProduct)
                        {
                            Console.WriteLine($"3C最便宜的商品:{product.ProductName}");
                        }
                        var FoodPriceMin = content.Where((x) => x.CommodityCategory == "食品").Min(x => decimal.Parse(x.Price));
                        var FoodPriceMinProduct = content.Where((x) => decimal.Parse(x.Price) == FoodPriceMin);
                        foreach (var product in FoodPriceMinProduct)
                        {
                            Console.WriteLine($"食品最便宜的商品:{product.ProductName}");
                        }
                        var BeveragePriceMin = content.Where((x) => x.CommodityCategory == "飲料").Min(x => decimal.Parse(x.Price));
                        var BeveragePriceMinProduct = content.Where((x) => decimal.Parse(x.Price) == BeveragePriceMin);
                        foreach (var product in BeveragePriceMinProduct)
                        {
                            Console.WriteLine($"飲料最便宜的商品:{product.ProductName}");
                        }
                        break;

                    case 16:
                        var PriceLessThanOrEqualTo10000 = content.Where(x => decimal.Parse(x.Price) <= 1000);
                        Console.WriteLine($"價格小於等於 10000 的商品:");
                        foreach (var product in PriceLessThanOrEqualTo10000)
                        {
                            Console.WriteLine($"{product.ProductName}");
                        }
                        break;
   
                }
            
            }while(true);







        }
        



    }

}
