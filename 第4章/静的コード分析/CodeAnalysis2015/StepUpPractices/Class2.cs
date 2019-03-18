using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepUpPractices
{
    public class Class2
    {

        // リスト4.5　英語のスペルミスのコード例 と同じコード（カスタム辞書により警告にならない）
        public int Hoge { get; set; }

        public void ExecuteSomething()
        {
            this.Hoge += 1;
        }

    }
}
