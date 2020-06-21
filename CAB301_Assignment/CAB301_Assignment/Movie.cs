using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB301_Assignment
{
    public class Movie
    {
        //Declare Variables
        private string title;
        private string star;
        private string director;
        private int duration;
        private string genre;
        private string classification;
        private DateTime releaseDate;
        private int timesBorrowed;

        //Set the variables
        public Movie(string movieTitle, string movieStar, string movieDirector, int movieDuration, string movieGenre, string movieClassification, DateTime movieReleaseDate)
        {
            title = movieTitle;
            star = movieStar;
            director = movieDirector;
            duration = movieDuration;
            genre = movieGenre;
            classification = movieClassification;
            releaseDate = movieReleaseDate;
        }

        public string getTitle()
        {
            return title;
        }

        public void Borrowed()
        {
            //Increasing the number of times the movie has been borrowed
            timesBorrowed++;
        }

        public int getBorrowed()
        {
            return timesBorrowed;
        }
    }
}
