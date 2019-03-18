using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepUpPractices
{
    // 簡単に IDisposable を実装するためのコードスニペットはこちらからダウンロード出来ます
    // https://visualstudiogallery.msdn.microsoft.com/5b63f911-3383-412c-a85b-8b9af21c33b9

    public class Class1 :IDisposable
    {
        // インターフェイス実装・オーバーライド

        #region IDisposable メンバー

        /// <summary>
        /// アンマネージ リソースの解放およびリセットに関連付けられているアプリケーション定義のタスクを実行します。
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        } // end sub

        /// <summary>
        /// インスタンスを解放します。
        /// </summary>
        ~Class1()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// 重複する呼び出しを検出するために使用されるバッキングフィールドです。
        /// </summary>
        private bool disposedValue = false;

        /// <summary>
        /// インスタンスが使用しているアンマネージオブジェクト、およびマネージオブジェクトを解放します。
        /// </summary>
        /// <param name="disposing">マネージオブジェクトを明示的に解放する時は True を指定します。それ以外は False を指定します。</param>
        protected virtual void Dispose(bool disposing)
        {

            if (this.disposedValue == false)
            {
                if (disposing)
                {
                    // TODO: マネージ オブジェクトを解放します。
                    if( this.stream  != null)
                    {
                        this.stream.Dispose();
                        this.stream = null;
                    }
                } // end if

                // TODO: アンマネージ オブジェクトを解放します。
            } // end if

            this.disposedValue = true;
        } // end sub

        #endregion

        // クラスメンバー

        #region コンストラクタ

        public Class1(System.IO.Stream stream)
{
            if (stream == null) throw new ArgumentNullException("stream");
            this.stream = stream;
        }

        private System.IO.Stream stream;

        #endregion

        #region メソッド

        public void ExecuteSomething(byte[] data)
    {
            // このサンプルは、ここで this.stream を使用した何かを実行する事をイメージしています。
            this.stream.Write(data,0,0);

        } // end sub

        #endregion

    } // end class
} // end namespace
