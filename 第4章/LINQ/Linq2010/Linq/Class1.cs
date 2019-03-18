using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmSample.Data
{
    public class Class1
    {
        // リスト4.36  LINQ クエリ式（上）とメソッド式（下）

        public IEnumerable<Data.ViewModels.ViewProduct> GetViewProducts()
        {
            using (var db = new MvvmSample.Data.MvvmSampleModelContainer())
            {
                var results =
                    from p in (
                        from p in db.Products
                        where p.Price > 1000
                        where p.DownloadUrl != null
                        where p.DownloadUrl != ""
                        select p).ToList()
                    select Data.ViewModels.ViewProduct.FromProduct(p);
                return results.ToList();

            } // end using
        } // end function

        public IEnumerable<Data.ViewModels.ViewProduct> GetViewProducts2()
        {
            using (var db = new MvvmSample.Data.MvvmSampleModelContainer())
            {
                var r2 =
                    db.Products
                        .Where(p => p.Price > 1000)
                        .Where(p => p.DownloadUrl != null)
                        .Where(p => p.DownloadUrl != "")
                        .ToList()
                            .Select(p => Data.ViewModels.ViewProduct.FromProduct(p));
                return r2.ToList();

            } // end using
        } // end function

        public IEnumerable<Data.ViewModels.ViewProduct> GetExampleViewProducts()
        {
            using (var db = new MvvmSample.Data.MvvmSampleModelContainer())
            {
                // リスト4.37 ラムダ式を使用するLINQ to Objectの例
                var regex = new System.Text.RegularExpressions.Regex(@"^http://example\.com");
                Func<string, bool> isExample = url => regex.IsMatch(url);
                var results =
                    from p in (
                        from p in db.Products
                        select p).ToList()
                    where isExample(p.DownloadUrl)
                        || isExample(p.ProductUrl)
                        || isExample(p.PublisherUrl)
                    select Data.ViewModels.ViewProduct.FromProduct(p);

                return results.ToList();

            } // end using
        } // end function


        public IEnumerable<decimal?> GetTotalPrices()
        {
            using (var db = new MvvmSample.Data.MvvmSampleModelContainer())
            {
                // リスト4.39 from from、group by、Distinct、Sumの例
                var results =
                    (from p in db.Products
                     group p by p.Publisher into g
                     from u in g
                     select new
                     {
                         TotalPrice = g.Sum(p => p.Price),
                         Publisher = u.Publisher
                     }).Distinct();

                return (from r in results select r.TotalPrice).ToList();
            } // end using
        } // end function

        public decimal? GetTotalPrice(string publisher)
        {
            using (var db = new MvvmSample.Data.MvvmSampleModelContainer())
            {
                // リスト4.40 group by と Sum を使った集計の例
                return (
                    from p in db.Products
                    where p.Publisher == publisher
                    group p by p.Publisher into g
                    select new
                    {
                        TotalPrice = g.Sum(p => p.Price)
                    }
                ).FirstOrDefault().TotalPrice;

            } // end using
        } // end function


    } // end class
} // end namespace
