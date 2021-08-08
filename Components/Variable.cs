﻿using System.Collections.Generic;
using static lambda_cs.Evaluation.Utility;

namespace lambda_cs.Components
{
    class Variable : LExpr
    {
        // single character variable name 
        private char var;

        public Variable(char v)
        {
            this.var = v;
        }

        public char GetVar()
        {
            return this.var;
        }

        // collects free variables by adding the only one in scope - itself
        public override List<char> GetFreeVars()
        {
            return new List<char>() { this.var };
        }

        // collects no bound variables because there can be none here
        public override List<char> GetBoundVars()
        {
            return new List<char>();
        }

        // tries to reduce this variable
        public override LExpr Reduce(Evaluation _, bool annotate)
        {
            // a variable is already in normal form
            lastOperation = Operation.None;
            Log("== reached NF ==", annotate);
            return this;
        }

        // this variable is only equal to another one if the name is equal
        public override bool Equals(LExpr other)
        {
            if (other is Variable)
            {
                var otherVar = other as Variable;
                return this.var.Equals(otherVar.GetVar());
            }
            else
            {
                return false;
            }
        }

        // converts the character name to a string
        public override string ToString()
        {
            return this.var.ToString();
        }
    }
}
