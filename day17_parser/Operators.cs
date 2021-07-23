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

        private Dictionary<string, Precedence> _map = new Dictionary<string, Precedence>();
        public void Add(string name, int prec, bool leftAssoc)
        {
            _map.Add( name, new Precedence(prec, leftAssoc) );
        }

        public Precedence Get(string key)
        {
            Precedence value = null;
            _map.TryGetValue( key, out value);
            return value;
        }
    }
}