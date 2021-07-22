using System;
using System.Collections.Generic;

/*
 * 操作符
 * 包括优先级别，左右结合定义
 * 例如：+ - * / % = == < > 
 *
 */
namespace week2
{
    public class Operators: Dictionary<string, Precedence>
    {
        public static bool LEFT = true;
        public static bool RIGHT = false;
        public void Add(string name, int prec, bool leftAssoc)
        {
            this.Add( name, new Precedence(prec, leftAssoc) );
        }

        public Precedence Get(string key)
        {
            return this.Get(key);
        }
    }
}