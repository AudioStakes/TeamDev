using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAnalysis
{
    public class Class1
    {
        // ※ 静的コード分析は、警告が多すぎる場合は一度に全ての警告が表示されない場合があります。
        // 　その場合は警告を修正してください。他の警告が表示されるようになります。

        // ※このサンプルでは、コードを修正する例については、修正後のコードをコメントアウトしています。
        // 　使用するには［選択範囲のコメントを解除 Ctrl + K, Ctrl + U］を使ってコメントを解除してください。

        // リスト 4.1　使用されていないprivate変数宣言のコード例
        private string Test;


        // リスト4.2 IDisposableのDispose忘れコード例
        public static void DoNotDisposeFileStream(string fileName, byte[] data)
        {
            var stream = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Write);
            stream.Write(data, 0, 0);
        }

        // リスト4.3 try/finallyブロックでIDisposableのDisposeを実行する
        //public static void DoNotDisposeFileStream(string fileName, byte[] data)
        //{
        //    System.IO.FileStream stream = null;
        //    try
        //    {
        //        stream = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Write);
        //        stream.Write(data, 0, 0);
        //    }
        //    finally
        //    {
        //        if (stream != null) stream.Dispose();
        //    }
        //}

        // リスト4.4 usingブロックでIDisposableのDisposeを実行する
        //public static void DoNotDisposeFileStream(string fileName, byte[] data)
        //{
        //    using (var stream = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Write))
        //    {
        //        stream.Write(data, 0, 0);
        //    }
        //}

        // リスト4.5　英語のスペルミスのコード例
        public int Hoge { get; set; }

        // Note
        //（2015年6月20日現在）Visual Studio 2010～2015の日本語表示では、ここで解説するMicrosoft.Namingカテゴリの規則セットが正常に動作しません。
        // この静的コード分析を使用するには、Visual Studioの表示言語を英語に変更してください。

        // リスト 4.6 意味なく複雑なコード例
        public static bool IsSuccess(
            int a,
            int b,
            int c,
            int d,
            int e,
            int f,
            int g,
            int h,
            int i,
            int j,
            int k,
            int l,
            int m,
            int n,
            int o,
            int p,
            int q,
            int r,
            int s,
            int t,
            int u,
            int v,
            int w,
            int x,
            int y,
            int z)
        {

            bool result = false;

            if (result == false && a < 100)
            {
                var value = 0;
                for (var counter = 0; counter < a; counter++)
                {
                    value += a;
                }
                result = value < 100;
            }
            else
            {
                result = true;
            }
            if (result == false && b < 100)
            {
                var value = 0;
                for (var counter = 0; counter < b; counter++)
                {
                    value += b;
                }
                result = value < 100;
            }
            else
            {
                result = true;
            }
            if (result == false && c < 100)
            {
                var value = 0;
                for (var counter = 0; counter < c; counter++)
                {
                    value += c;
                }
                result = value < 100;
            }
            else
            {
                result = true;
            }
            if (result == false && d < 100)
            {
                var value = 0;
                for (var counter = 0; counter < d; counter++)
                {
                    value += d;
                }
                result = value < 100;
            }
            else
            {
                result = true;
            }
            if (result == false && e < 100)
            {
                var value = 0;
                for (var counter = 0; counter < e; counter++)
                {
                    value += e;
                }
                result = value < 100;
            }
            else
            {
                result = true;
            }
            if (result == false && f < 100)
            {
                var value = 0;
                for (var counter = 0; counter < f; counter++)
                {
                    value += f;
                }
                result = value < 100;
            }
            else
            {
                result = true;
            }
            if (result == false && g < 100)
            {
                var value = 0;
                for (var counter = 0; counter < g; counter++)
                {
                    value += g;
                }
                result = value < 100;
            }
            else
            {
                result = true;
            }
            if (result == false && h < 100)
            {
                var value = 0;
                for (var counter = 0; counter < h; counter++)
                {
                    value += h;
                }
                result = value < 100;
            }
            else
            {
                result = true;
            }
            if (result == false && i < 100)
            {
                var value = 0;
                for (var counter = 0; counter < i; counter++)
                {
                    value += i;
                }
                result = value < 100;
            }
            else
            {
                result = true;
            }
            if (result == false && j < 100)
            {
                var value = 0;
                for (var counter = 0; counter < j; counter++)
                {
                    value += j;
                }
                result = value < 100;
            }
            else
            {
                result = true;
            }
            if (result == false && k < 100)
            {
                var value = 0;
                for (var counter = 0; counter < k; counter++)
                {
                    value += k;
                }
                result = value < 100;
            }
            else
            {
                result = true;
            }
            if (result == false && l < 100)
            {
                var value = 0;
                for (var counter = 0; counter < l; counter++)
                {
                    value += l;
                }
                result = value < 100;
            }
            else
            {
                result = true;
            }
            if (result == false && m < 100)
            {
                var value = 0;
                for (var counter = 0; counter < m; counter++)
                {
                    value += m;
                }
                result = value < 100;
            }
            else
            {
                result = true;
            }
            if (result == false && n < 100)
            {
                var value = 0;
                for (var counter = 0; counter < n; counter++)
                {
                    value += n;
                }
                result = value < 100;
            }
            else
            {
                result = true;
            }
            if (result == false && o < 100)
            {
                var value = 0;
                for (var counter = 0; counter < o; counter++)
                {
                    value += o;
                }
                result = value < 100;
            }
            else
            {
                result = true;
            }
            if (result == false && p < 100)
            {
                var value = 0;
                for (var counter = 0; counter < p; counter++)
                {
                    value += p;
                }
                result = value < 100;
            }
            else
            {
                result = true;
            }
            if (result == false && q < 100)
            {
                var value = 0;
                for (var counter = 0; counter < q; counter++)
                {
                    value += q;
                }
                result = value < 100;
            }
            else
            {
                result = true;
            }
            if (result == false && r < 100)
            {
                var value = 0;
                for (var counter = 0; counter < r; counter++)
                {
                    value += r;
                }
                result = value < 100;
            }
            else
            {
                result = true;
            }
            if (result == false && s < 100)
            {
                var value = 0;
                for (var counter = 0; counter < s; counter++)
                {
                    value += s;
                }
                result = value < 100;
            }
            else
            {
                result = true;
            }
            if (result == false && t < 100)
            {
                var value = 0;
                for (var counter = 0; counter < t; counter++)
                {
                    value += t;
                }
                result = value < 100;
            }
            else
            {
                result = true;
            }
            if (result == false && u < 100)
            {
                var value = 0;
                for (var counter = 0; counter < u; counter++)
                {
                    value += u;
                }
                result = value < 100;
            }
            else
            {
                result = true;
            }
            if (result == false && v < 100)
            {
                var value = 0;
                for (var counter = 0; counter < v; counter++)
                {
                    value += v;
                }
                result = value < 100;
            }
            else
            {
                result = true;
            }
            if (result == false && w < 100)
            {
                var value = 0;
                for (var counter = 0; counter < w; counter++)
                {
                    value += w;
                }
                result = value < 100;
            }
            else
            {
                result = true;
            }
            if (result == false && x < 100)
            {
                var value = 0;
                for (var counter = 0; counter < x; counter++)
                {
                    value += x;
                }
                result = value < 100;
            }
            else
            {
                result = true;
            }
            if (result == false && y < 100)
            {
                var value = 0;
                for (var counter = 0; counter < y; counter++)
                {
                    value += y;
                }
                result = value < 100;
            }
            else
            {
                result = true;
            }
            if (result == false && z < 100)
            {
                var value = 0;
                for (var counter = 0; counter < z; counter++)
                {
                    value += z;
                }
                result = value < 100;
            }
            else
            {
                result = true;
            }

            return result;
        }

        // リスト4.7　CA1062警告となるコード例
        public static string CreateTransactionId(System.IO.FileInfo userFile)
        {
            return "TR" + userFile.FullName.GetHashCode();
        }

        // リスト4.8 Visual Studio 2015の null条件演算子を使って修正するコード例
        //public static string CreateTransactionId(System.IO.FileInfo userFile)
        //{
        //    return "TR" + userFile?.FullName?.GetHashCode() ?? System.Guid.NewGuid().ToString();
        //}

        // リスト4.9 null条件演算子を使わずに修正するコード例
        //public static string CreateTransactionId(System.IO.FileInfo userFile)
        //{
        //    return "TR" + ((userFile != null && userFile.FullName != null) ? userFile.FullName.GetHashCode().ToString() : System.Guid.NewGuid().ToString());
        //}

        // リスト 4.10 引数検証のコード例
        //public static string CreateTransactionId(System.IO.FileInfo userFile)
        //{
        //    if (userFile == null) throw new ArgumentNullException("userFile");
        //    return "TR" + userFile.FullName.GetHashCode();
        //}

    }
}
