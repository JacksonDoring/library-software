using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB301_Assignment
{
    class Member
    {
        private string fname;
        private string lname;
        private string address;
        private int number;
        private List<string> borrowedMovies = new List<string>();
        private int password;

        public Member(string firstName, string lastName, string residentalAdd, int contactNumber, int pass)
        {
            fname = firstName;
            lname = lastName;
            address = residentalAdd;
            number = contactNumber;
            password = pass;
        }

        //Displaying the curren movies borrowed by the member
        public void ListBorrowedMovies()
        {
            foreach (string i in borrowedMovies)
            {
                Console.WriteLine(i);
            }
        }

        //Adding movie to the members borrowed array
        public int AddMovie(string movie)
        {
            //If the borrowedMovies array is empty then just add the movie
            if (borrowedMovies.Count == 0)
            {
                borrowedMovies.Add(movie);
                return 1;
            }
            else if (borrowedMovies.Count <= 9)
            {
                //Seeing if the movie already exists in the moviesBorrowed array
                for (int i = 0; i < borrowedMovies.Count; i++)
                {
                    if (borrowedMovies[i] == movie)
                    {
                        //If it does return -1
                        return -1;
                    }
                }

                //If the member doesn't already have the movie borrowed
                borrowedMovies.Add(movie);
                return 1;
            }
            //If the member already has 10 movies borrowed
            else
            {
                return -2;
            }
        }

        public int ReturnMovie(string movie)
        {
            //Checking if the member has the movie borrowed
            for (int i = 0; i < borrowedMovies.Count; i++)
            {
                if (string.Compare(movie, borrowedMovies[i]) == 0)
                {
                    //Removing the movie from moviesBorrowed
                    borrowedMovies.Remove(movie);
                    return 1;
                }
            }
            return -1;
        }

        public string getUsername()
        {
            return fname + lname;
        }

        public int getNumber()
        {
            return number;
        }

        public int getPassword()
        {
            return password;
        }

    }
}
