using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB301_Assignment
{
    public class MovieTreeNode
    {

        private Movie movie;
        public Movie Movie
        {
            get { return movie; }
        }

        private MovieTreeNode rightNode;
        public MovieTreeNode RightNode
        {
            get { return rightNode; }
            set { rightNode = value; }
        }

        private MovieTreeNode leftNode;
        public MovieTreeNode LeftNode
        {
            get { return leftNode; }
            set { leftNode = value; }
        }

        private bool isDeleted;
        private string movieTitleAdd;

        public MovieTreeNode(Movie movieAdd)
        {
            movie = movieAdd;
        }

        public bool IsDeleted
        {
            get { return isDeleted; }
        }

        //Function for finding a movie in the tree
        public MovieTreeNode Find(Movie movie)
        {
            string movieTitle = movie.getTitle();
            MovieTreeNode currentNode = this;

            //While there is still a node to search in
            while (currentNode != null)
            {
                //If the movie it's searching for is the current node, return the node
                if (string.Compare(movieTitle, currentNode.movie.getTitle()) == 0 && isDeleted == false)
                {
                    return currentNode;
                }
                //If the movie is less than the current node and the left subtree is not empty, search the left subtree
                else if (string.Compare(movieTitle, currentNode.movie.getTitle()) < 0 && leftNode != null)
                {
                    return leftNode.FindRecursive(movie);
                }
                //Otherwise search the right subtree if it's not empty
                else if (rightNode != null)
                {
                    return rightNode.FindRecursive(movie);
                }
                //The movie doesn't exist in the tree
                else
                {
                    return null;
                }
            }

            return null;
        }

        //Function for recursively searching the tree
        public MovieTreeNode FindRecursive(Movie movie)
        {
            string movieTitleFind = movie.getTitle();

            //If the movie equals the current node, return the node
            if (string.Compare(movieTitleFind, movie.getTitle()) == 0)
            {
                return this;
            }
            //If the movie is less than the current node and the left subtree is not empty, search the left subtree
            else if (string.Compare(movieTitleFind, movie.getTitle()) < 0 && leftNode != null)
            {
                return leftNode.FindRecursive(movie);
            }
            //Otherwise search the right subtree if it's not empty
            else if (rightNode != null)
            {
                return rightNode.FindRecursive(movie);
            }
            //The movie doesn't exists in the tree
            else
            {
                return null;
            }
        }

        //Function for inserting a movie object into the tree
        public void Insert(Movie movieAdd)
        {
            string movieTitileAdd = movieAdd.getTitle();

            //If the movie to be added is greatter than the current node
            if (string.Compare(movieTitleAdd, movie.getTitle()) >= 0)
            {
                if (rightNode == null)
                {
                    //Movie is added to the right of the parent node if the right subtree is empty
                    rightNode = new MovieTreeNode(movieAdd);
                }
                else
                {
                    //If the right subtree isn't empty, go to the right subtree
                    rightNode.Insert(movieAdd);
                }
            }
            //If the movie to be added is less than the current node
            else
            {
                //If the left subtree is empty, add the movie to the left subtree
                if (leftNode == null)
                {
                    leftNode = new MovieTreeNode(movieAdd);
                }
                //If it isn't empty, go to the left subtree
                else
                {
                    leftNode.Insert(movieAdd);
                }
            }
        }

        //Traversing through the whole tree
        public void MoviePreOrderTraversal()
        {
            //Outputting the current node's movie title
            Console.WriteLine(movie.getTitle());

            //If the left subtree ins't empty, search through it
            if (leftNode != null)
            {
                leftNode.MoviePreOrderTraversal();
            }

            //If the right subtree ins't empty, search through it
            if (rightNode != null)
            {
                rightNode.MoviePreOrderTraversal();
            }
        }

        //Function for getting the top ten borrowed movies
        public void TopTen(MovieCollection movieCollection)
        {
            //Adding the current movie node to the borrowed array
            movieCollection.AddToBorrow(movie);

            //If the left subtree isn't empty, search through it
            if (leftNode != null)
            {
                //Searching the left subtree
                leftNode.TopTen(movieCollection);
            }

            //If the right subtree isn't empty, search through it
            if (rightNode != null)
            {
                //Searching the right subtree
                rightNode.TopTen(movieCollection);
            }

        }

        //Function for seeing if a movie exists
        public int SearchMovies(string movieTitle)
        {

            //If the movie to search for equals the current node, return 1
            if (movie.getTitle() == movieTitle)
            {
                return 1;
            }
            else
            {
                //If the left subtree ins't empty, search through it
                if (leftNode != null)
                {
                    return leftNode.SearchMovies(movieTitle);
                }

                //If the right subtree ins't empty, search through it
                if (rightNode != null)
                {
                    return rightNode.SearchMovies(movieTitle);
                }
            }

            //If the movie doesn't exist in the tree, return -1
            return -1;
        }


        //Fcuntion for getting how many times a movie has been borrowed
        public void MovieCounter(string movieTitle)
        {

            //If the movie equals the current node, get how many times it has been borrowed
            if (movie.getTitle() == movieTitle)
            {
                movie.Borrowed();
            }
            else
            {
                //If the left subtree ins't empty, search through it
                if (leftNode != null)
                {
                    leftNode.MovieCounter(movieTitle);
                }

                //If the right subtree isn't empty, search through it
                if (rightNode != null)
                {
                    rightNode.MovieCounter(movieTitle);
                }
            }
        }
    }
}
