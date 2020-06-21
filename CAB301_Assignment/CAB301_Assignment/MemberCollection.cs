using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB301_Assignment
{
    class MemberCollection
    {
        private Member[] memberArray = { };

        //Adding a member to the array
        public void AddMember(Member newMember)
        {
            //Resizing the array
            int newSize = memberArray.Length + 1;
            Array.Resize(ref memberArray, newSize);

            //Adding the member to the array
            memberArray[newSize - 1] = newMember;

            //Sorting the new array
            QuickSort(memberArray, 0, memberArray.Length - 1);
        }

        public int Partition(Member[] arr, int left, int right)
        {
            string pivot;
            pivot = arr[left].getUsername();
            while (true)
            {
                //While left is smaller than the pivot move it to the right
                while (string.Compare(arr[left].getUsername(), pivot) < 0)
                {
                    left++;
                }
                //While right is greatter than the pivot move it down
                while (string.Compare(arr[right].getUsername(), pivot) > 0)
                {
                    right--;
                }
                //If left index is less than right index, swap them around
                if (left < right)
                {
                    Member temp = arr[right];
                    arr[right] = arr[left];
                    arr[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

        //Quick sort method for sorting the member array each time a member is added
        public void QuickSort(Member[] arr, int left, int right)
        {
            int pivot;

            if (left < right)
            {
                //Getting the pivot point of the array
                pivot = Partition(arr, left, right);

                //If pivot is greatter than 1
                if (pivot > 1)
                {
                    QuickSort(arr, left, pivot - 1);
                }
                //If pivot + 1 is less than the right value
                if (pivot + 1 < right)
                {
                    QuickSort(arr, pivot + 1, right);
                }
            }

            //Once the whole array has been sorted
            memberArray = arr;
        }

        //Searching to see if the username exists in the array
        public int BinarySearch(string username)
        {
            int l = 0;
            int r = memberArray.Length - 1;

            //Searching through the whole array
            while (l <= r)
            {
                //Staring in the middle of the array
                int m = (l + r) / 2;
                if (username == memberArray[m].getUsername())
                {
                    //If the middle index is the username it's searching for return the index
                    return m;
                }
                //If the username it's searching for is less than the middle, search the lower half
                else if (string.Compare(username, memberArray[m].getUsername()) < 0)
                {
                    r = m - 1;
                }
                //If the username it's searching for is greater than the middle, search the upper half
                else
                {
                    l = m + 1;
                }
            }

            //If the whole array is searched, then the username doesn't exist
            return -1;
        }

        //For adding movies to the members borrowed array
        public int AddBorrowedMovie(string username, string movieTitle)
        {
            //Checking if the username exists
            int memberIndex = BinarySearch(username);

            //If the username exists, try and add the movie
            if (memberIndex >= 0)
            {
                int added = memberArray[memberIndex].AddMovie(movieTitle);
                return added;
            }
            else
            {
                return -1;
            }
        }

        //Function for returning movie
        public int ReturnMovie(string username, string movieTitle)
        {
            //Checking if the username exists
            int memberIndex = BinarySearch(username);

            //If the username exists, try and return the movie
            if (memberIndex >= 0)
            {
                int returned = memberArray[memberIndex].ReturnMovie(movieTitle);
                return returned;
            }
            else
            {
                return -1;
            }
        }

        //List a members current borrowed movies
        public void ListBorrowedMovies(string username)
        {
            //Checking if the username exists
            int memberIndex = BinarySearch(username);

            //If the username exists, lit their currently borrowed movies
            if (memberIndex >= 0)
            {
                memberArray[memberIndex].ListBorrowedMovies();
            }
        }

        public void MemberNumber(string username)
        {
            //Checking if the username exists
            int index = BinarySearch(username);

            //If the username exists, get their phone number
            if (index >= 0)
            {
                int memberNumber = memberArray[index].getNumber();
                Console.WriteLine("The members contact number is " + memberNumber);
            }
            else
            {
                Console.WriteLine("The username you entered does not exist in the system");
            }
        }

        //Function for checking members password when logging in
        public int CheckPassword(int index)
        {
            int password = memberArray[index].getPassword();
            return password;
        }

        //Function for testing
        public void OutputArray()
        {
            for (int i = 0; i < memberArray.Length; i++)
            {
                Console.Write(memberArray[i].getUsername() + ", ");
            }
        }
    }
}
