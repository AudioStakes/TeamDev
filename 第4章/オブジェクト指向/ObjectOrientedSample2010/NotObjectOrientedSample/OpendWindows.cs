using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotObjectOrientedSample
{
    // ステップアップ課題 4.10  ー オブジェクト指向ではない例

    public static class OpendWindows
    {
        // ※ジェネリックをネストする実装は推奨されません。これは悪いサンプルです。
        // 　オブジェクト指向のサンプルと比較してください。
        // 　本当のオブジェクト指向であれば、ジェネリックをネストする必要が無いことが分かります。
        private static Dictionary<MainWindow, List<MainWindow>> mappingParentToChildren = new Dictionary<MainWindow, List<MainWindow>>();

        public static void OpenNewChild(MainWindow parent)
        {
            List<MainWindow> list = null;
            if (OpendWindows.mappingParentToChildren.ContainsKey(parent))
            {
                list = OpendWindows.mappingParentToChildren[parent];
            }
            else
            {
                list = new List<MainWindow>();
                OpendWindows.mappingParentToChildren.Add(parent, list);
            } // end if

            var w = new MainWindow();
            list.Add(w);
            w.Show();
        }

        public static void CloseChildren(MainWindow parent)
        {
            if (OpendWindows.mappingParentToChildren.ContainsKey(parent))
            {
                var list = OpendWindows.mappingParentToChildren[parent];
                foreach (var w in list)
                {
                    w.Close();
                }
                OpendWindows.mappingParentToChildren.Remove(parent);
            } // end if

        }
    }
}
