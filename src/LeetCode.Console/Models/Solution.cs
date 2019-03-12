namespace LeetCode.Console.Models
{
    public class Solution
    {
        #region Methods

        #region #1 TwoSum

        public int[] TwoSum(int[] nums, int target)
        {
            int CurrentIndex = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                CurrentIndex = i;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[CurrentIndex] + nums[j] == target)
                        return new int[2] { CurrentIndex, j };
                }
            }

            return new int[2] { 0, 1 };
        }

        #endregion #1 TwoSum

        #region #2 AddTwoNumbers

        //ListNode First = new ListNode(2) { next = new ListNode(4) { next = new ListNode(3) } };
        //ListNode Second = new ListNode(5) { next = new ListNode(6) { next = new ListNode(4) } };
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode First = null, Second = null, Current = null, rezult = null;
            int value = 0;

            while (true)
            {
                First = l1; Second = l2;

                int FirstVal = First == null ? 0 : First.val;
                int SecondVal = Second == null ? 0 : Second.val;

                value = FirstVal + SecondVal + value;

                if (Current == null)
                {
                    rezult = NewListNode(value);
                    Current = rezult;
                }
                else
                {
                    Current.next = NewListNode(value);
                    Current = Current.next;
                }
                if (value >= 10) value = 1;
                else value = 0;

                if (l1?.next == null && l2?.next == null) break;
                l1 = l1?.next; l2 = l2?.next;
            }

            if (value != 0) Current.next = new ListNode(value);

            return rezult;
        }

        private ListNode NewListNode(int value) => value >= 10 ? new ListNode(value - 10) : new ListNode(value);

        #endregion #2 AddTwoNumbers

        #region #3 LengthOfLongestSubstring

        public int LengthOfLongestSubstring(string s)
        {
            int max = 0;
            if (s.Length < 1) return max;

            string subString = s[0].ToString();
            max = 1;

            for (int i = 1; i < s.Length; i++)
            {
                string subChar = s[i].ToString();
                if (!subString.Contains(subChar))
                {
                    subString += subChar;
                    if (subString.Length > max) max = subString.Length;
                }
                else
                {
                    int index = subString.IndexOf(subChar) + 1;
                    subString = subString.Substring(index, subString.Length - index) + subChar;
                }
            }

            return max;
        }

        #endregion #3 LengthOfLongestSubstring

        #region #4 FindMedianSortedArrays

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1.Length < 1)
            {
                return Mediana(nums2);
            }
            else if (nums2.Length < 1)
            {
                return Mediana(nums1);
            }
            else
            {
                if (nums1[nums1.Length - 1] <= nums2[0])
                {
                    int[] nums0 = AppendsArrays(nums1, nums2);
                    return Mediana(nums0);
                }
                else if (nums2[nums2.Length - 1] <= nums1[0])
                {
                    int[] nums0 = AppendsArrays(nums2, nums1);
                    return Mediana(nums0);
                }
                else
                {
                    int[] nums0 = AppendsArrays(nums2, nums1);
                    System.Array.Sort(nums0);
                    return Mediana(nums0);
                }
            }            
        }

        private int[] AppendsArrays(int[] nums1, int[] nums2)
        {
            var list = new System.Collections.Generic.List<int>();
            list.AddRange(nums1);
            list.AddRange(nums2);
            return list.ToArray();
        }

        private double Mediana(int[] nums)
        {
            if (nums.Length %2 == 0)
            {
                int middle = nums.Length / 2;
                int res = nums[middle] + nums[middle - 1];
                return res / 2.0;
            }
            else
            {
                return nums[nums.Length / 2];
            }
        }

        #endregion #4 FindMedianSortedArrays

        #region #5 LongestPalindrome

        public string LongestPalindrome(string s)
        {
            return "";
        }

        #endregion #5 LongestPalindrome

        #region #6 Convert

        public string Convert(string s, int numRows)
        {
            if (numRows == 1) return s;

            string[,] sMatrix = new string[numRows, s.Length];
            string rezult = "";

            int Row = 0, Cell = 0;
            bool Down = true;
            for (int i = 0; i < s.Length; i++)
            {
                sMatrix[Row, Cell] += s[i];
                if (Row == 0) Down = true;

                if (Down)
                {
                    if (Row < numRows-1) Row++;
                    else if (Row == numRows-1 && Row != 0)
                    {
                        Down = false;
                        Row--; Cell++;
                    }
                    else if (Row == 0)
                    {
                        Cell++;
                    }
                }
                else
                {
                    Row--; Cell++;
                    if (Row == 0) Down = true;
                }
            }
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < s.Length; j++)
                {
                    if (sMatrix[i, j] != null) rezult += sMatrix[i, j];
                }
            }

            return rezult;
        }

        #endregion #6 Convert

        #region #7 Reverse

        public int Reverse(int x)
        {
            bool IsNegative = x < 0;

            if (IsNegative) x *= -1;

            string rez = Reverse(x.ToString());
            int value;
            if (int.TryParse(rez, out value))
                return IsNegative ? -int.Parse(rez) : int.Parse(rez);
            else return 0;
        }

        public string Reverse(string x)
        {
            if (x.Length <= 1) return x;
            return Reverse(x.Substring(1)) + x[0];
        }

        #endregion #7 Reverse

        #region #8 MyAtoi

        //public int MyAtoi(string str)
        //{
        //    if (str.Length < 1) return 0;

        //    int rezult = 0;
        //    if (str[0] != ' ' && !IsInt(str[0].ToString())) return 0;
        //    else if (str[0] == ' ')
        //    {
        //        string strTmp = str.Replace(" ", "");
        //        if (strTmp[0] != ' ' && !IsInt(strTmp[0].ToString())) return 0;
        //    }

        //    string rezultStr = System.Text.RegularExpressions.Regex.Match(str, @"^[0-9+-]+$").Value;

        //    try { int.Parse(rezultStr); }
        //    catch (System.OverflowException error) { return rezultStr[0] == '-'? -2147483648 : 2147483647; }
        //    catch
        //    {
        //        for (int i = 0; i < str; i++)
        //        {

        //        }
        //        if (int.TryParse(str, out rezult))
        //        {
        //            return int.Parse(str);
        //        }
        //        return 0;
        //    }           
        //}

        //private bool IsInt(string s) => System.Text.RegularExpressions.Regex.Match(s, @"^[0-9+-]+$").Success;

        #endregion # MyAtoi

        #region #9 IsPalindrome

        public bool IsPalindrome(int x)
        {
            string xStr = x.ToString();
            if (xStr.Length < 2) return true;

            return xStr.Equals(Reverse(xStr));
        }

        #endregion #9 IsPalindrome

        #endregion Methods
    }
}