namespace LeetCode.Console.Models
{
    public class Solution
    {
        #region Methods

        #region TwoSum

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

        #endregion TwoSum

        #region AddTwoNumbers

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

        #endregion AddTwoNumbers

        #region LengthOfLongestSubstring

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

        #endregion LengthOfLongestSubstring

        #region FindMedianSortedArrays

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

        #endregion FindMedianSortedArrays

        #region LongestPalindrome

        public string LongestPalindrome(string s)
        {
            return "";
        }

        #endregion LongestPalindrome

        #endregion Methods
    }
}