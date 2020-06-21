using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB301_Assignment
{
    public class MovieCollection
    {
        Movie[] topTenMovies = { };

        private MovieTreeNode root;
        public MovieTreeNode Root
        {
            get { return root; }
        }

        //Function for finding node in the tree
        public MovieTreeNode Find(Movie movie)
        {
            if (root != null)
            {
                return root.Find(movie);
            }
            else
            {
                return null;
            }
        }

        //Function for finding node in tree
        public MovieTreeNode FindRecursive(Movie movie)
        {
            if (root != null)
            {
                return root.FindRecursive(movie);
            }
            else
            {
                return null;
            }
        }

        //Function for inserting node into tree
        public void Insert(Movie movieAdd)
        {
            if (root != null)
            {
                root.Insert(movieAdd);
            }
            else
            {
                //Movie is added as the root node
                root = new MovieTreeNode(movieAdd);
            }
        }

        //Function for traversing tree
        //Searches by: root => left => right
        public void MoviePreOrderTraversal()
        {
            if (root != null)
            {
                root.MoviePreOrderTraversal();
            }
        }

        //Function for listing top ten most borrowed movies
        public void TopTen(MovieCollection movieCollection)
        {
            //If the root node is not null
            if (root != null)
            {
                //Setting the topTenMovies array to null
                topTenMovies = null;

                //Getting an array of each of the movies
                root.TopTen(movieCollection);

                //Sorting the borrowed array into descending order by number of times borrowed
                BubbleSort(topTenMovies);
            }
        }

        //Function to sort borrowed array
        public void BubbleSort(Movie[] movies)
        {
            //Temp Movie object for swapping
            Movie temp;

            //Looping through the array n-1 times to make sure the whole array is sorted
            for (int j = 0; j <= movies.Length - 2; j++)
            {
                for (int i = 0; i <= movies.Length - 2; i++)
                {
                    //If the next position is larger than the current position, swap it with the current position
                    if (movies[i].getBorrowed() < movies[i + 1].getBorrowed())
                    {
                        //Swap positions in array
                        temp = movies[i + 1];
                        movies[i + 1] = movies[i];
                        movies[i] = temp;
                    }
                }
            }

            Console.WriteLine("Top 10 Movies Borrowed");

            //If the array has more than 10 vales, only output the first ten values
            if (movies.Length > 9)
            {
                //Loop through 10 times
                for (int i = 0; i < 10; i++)
                {
                    //Write the top ten movies to the console
                    Console.WriteLine(i + 1 + ". " + movies[i].getTitle() + " has been borrowed " + movies[i].getBorrowed() + " times");
                }
            }
            //If the array is less than 10, output the whole array
            else
            {
                //Loop through the length of the array
                for (int i = 0; i < movies.Length; i++)
                {
                    //Write the array to the console
                    Console.WriteLine(i + 1 + ". " + movies[i].getTitle() + " " + movies[i].getBorrowed());
                }
            }

        }

        //Adding movie to the topTenMovies array array
        public void AddToBorrow(Movie movie)
        {
            int newSize;
            if (topTenMovies == null)
            {
                newSize = 1;
            }
            else
            {
                newSize = topTenMovies.Length + 1;
            }

            //Resizing the array and adding the movie to the array
            Array.Resize(ref topTenMovies, newSize);
            topTenMovies[newSize - 1] = movie;
        }

        //Searching for a movie
        public int SearchMovies(string movieTitle)
        {
            //If root is not null then keep searching
            if (root != null)
            {
                int result = root.SearchMovies(movieTitle);
                return result;
            }
            return -1;
        }

        //Fucntion for getting how many times a movie has been borrowed
        public void MovieCounter(string movieTitle)
        {
            if (root != null)
            {
                root.MovieCounter(movieTitle);
            }
        }

        public int Remove(string movieTitle)
        {
            //Setting the the current node to the root
            MovieTreeNode current = root;
            //Setting the parent node to the root
            MovieTreeNode parent = root;
            bool leftChild = false;

            //If the tree is empty, then nothing happens
            if (current == null)
            {
                return -1;
            }

            //While the current search node does not equal the movie title we're searhing for and the current search node is not empty
            while (current != null)
            {
                parent = current;
                if (string.Compare(movieTitle, current.Movie.getTitle()) == 0)
                {
                    break;
                }
                //If the movie title we're searching for is less than the current node than we'll search the left side of the tree
                else if (string.Compare(movieTitle, current.Movie.getTitle()) < 0)
                {
                    //Setting the current node to the left node
                    current = current.LeftNode;
                    leftChild = true;
                }
                //Otherwise we'll search the right side of the tree
                else
                {
                    //Setting the current node to the right node
                    current = current.RightNode;
                    leftChild = false;
                }
            }

            //If the current node is empty, then nothing happens
            if (current == null)
            {
                return -1;
            }

            //If the movie title to be deleted is a leaf
            if (current.RightNode == null && current.LeftNode == null)
            {
                //If the movieTitle to be deleted is the root node
                if (current == root)
                {
                    root = null;
                }
                else
                {
                    //If the current node is a left child
                    if (leftChild)
                    {
                        //Removing the movie from the tree
                        parent.LeftNode = null;
                    }
                    else
                    {
                        //Removing the movie from the tree
                        parent.RightNode = null;
                    }
                }
            }
            //If the node to be deleted only has a left child
            else if (current.RightNode == null)
            {
                //If the node to be deleted is the root
                if (current == root)
                {
                    //Move the left child to the root
                    root = current.LeftNode;
                }
                else
                {
                    //If node to be deleted is a left child
                    if (leftChild)
                    {
                        //Setting the parents left node to the current node
                        parent.LeftNode = current.LeftNode;
                    }
                    else
                    {
                        parent.RightNode = current.LeftNode;
                    }
                }
            }
            //If the node to be deleted only has a right child
            else if (current.LeftNode == null)
            {
                //If the node to be deleted is the root
                if (current == root)
                {
                    //Setting the root to the right child
                    root = current.RightNode;
                }
                else
                {
                    if (leftChild)
                    {
                        //Setting the parents left node to the current node
                        parent.LeftNode = current.RightNode;
                    }
                    else
                    {
                        //Setting the parents right node to the current node
                        parent.RightNode = current.RightNode;
                    }
                }
            }
            //If the node to be deleted has a left and right child
            else
            {
                MovieTreeNode replacement = Replacement(current);

                //If the node to be deleted is the root node
                if (current == root)
                {
                    root = replacement;
                }
                //If the node to be deleted is a left child
                else if (leftChild)
                {
                    parent.LeftNode = replacement;
                }
                //If the node to be deleted is a right child
                else
                {
                    parent.RightNode = replacement;
                }
            }

            return 1;
        }

        private MovieTreeNode Replacement(MovieTreeNode currentNode)
        {
            MovieTreeNode replacementParent = currentNode;
            MovieTreeNode replacement = currentNode;
            MovieTreeNode current = currentNode;

            //Finding the last left node of the right node
            while (current != null)
            {
                replacementParent = replacement;
                replacement = current;
                current = current.LeftNode;
            }

            //If the right node of the node to be deleted has atleast one left node
            if (replacement != currentNode.RightNode)
            {
                replacementParent.LeftNode = replacement.RightNode;
                //Moving the right node of the node to be deleted to the right of the replacement node
                replacement.RightNode = currentNode.RightNode;
            }
            //Moving the left child of the node to be deleted to the left child of the deleted nodes right child
            replacement.LeftNode = currentNode.LeftNode;

            return replacement;
        }

    }
}
