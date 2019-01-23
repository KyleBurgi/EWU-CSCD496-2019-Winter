using SecretSanta.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SecretSanta.Import
{
    public class Import
    {
        public string DirectoryPath { get; set; }

        public Import(string directoryPath)
        {
            if (directoryPath == null)
                throw new ArgumentNullException(nameof(directoryPath));

            else if (File.Exists(directoryPath) == false)
                throw new ArgumentException(nameof(directoryPath));

            else if (HeaderExists(File.ReadLines(directoryPath).First()) == false)
                throw new ArgumentException(nameof(directoryPath));

            DirectoryPath = directoryPath;
        }

        public Boolean HeaderExists(string headerString)
        {
            string[] regexArray = headerString.Split(':');

            if (regexArray.Length != 2)
                return false;

            if (regexArray[0].Equals("Name") == false)
                return false;

            return true;
        }

        public User ReadHeader()
        {
            string header = File.ReadLines(DirectoryPath).First();
            string[] regexArray = header.Split(':');

            if (regexArray.Length != 2)
                throw new ArgumentException(nameof(DirectoryPath));
            if (regexArray[0].Equals("Name") == false)
                throw new ArgumentException(nameof(DirectoryPath));

            string name = regexArray[1].Trim();
            string[] nameArray = name.Split(',');

            if (nameArray.Length == 2)
            { 
                return new User(nameArray[1], nameArray[0]);
            }

            if (nameArray.Length == 1)
            {
                string[] normalNameSplit = nameArray[0].Split(' ');
                return new User(normalNameSplit[0], normalNameSplit[1]);
            }

            throw new ArgumentException(nameof(DirectoryPath));
        }

        public List<Gift> ReadFileGifts(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            List<Gift> giftList = new List<Gift>();

            File.ReadLines(DirectoryPath).Skip(1);

            return null;
            
        }

    }
}
