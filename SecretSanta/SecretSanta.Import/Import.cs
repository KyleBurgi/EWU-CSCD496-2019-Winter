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

        public Import() { }
        public Import(string directoryPath)
        {
            if (directoryPath == null)
                throw new ArgumentNullException(nameof(directoryPath));

            else if (File.Exists(directoryPath) == false)
                throw new ArgumentException(nameof(directoryPath));

            else if (ProperHeaderExists(File.ReadLines(directoryPath).First()) == false)
                throw new ArgumentException(nameof(directoryPath));

            DirectoryPath = directoryPath;
        }

        public Boolean ProperHeaderExists(string headerString)
        {
            string[] regexArray = headerString.Split(':');

            if (regexArray.Length == 2)
                return true;

            if (regexArray[0].Trim().Equals("Name"))
                return true;

            return false;
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
                return new User(nameArray[1].Trim(), nameArray[0].Trim());
            }

            if (nameArray.Length == 1)
            {
                string[] normalNameSplit = nameArray[0].Split(' ');
                return new User(normalNameSplit[0].Trim(), normalNameSplit[1].Trim());
            }

            throw new ArgumentException(nameof(DirectoryPath));
        }

        public List<Gift> ReadFileGifts(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            List<Gift> giftList = new List<Gift>();
            int count = 0;
            string giftString = null;

            var fileStream = new FileStream(DirectoryPath, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                while ((giftString = streamReader.ReadLine()) != null)
                {
                    if (count == 0) { }
                    else
                        giftList.Add(new Gift(giftString, count));

                    count++;
                }
            }

            if (giftList.Count == 0)
                throw new ArgumentException(nameof(user), "Wishlist is Empty");

            user.Gifts = giftList;
            fileStream.Close();
            return giftList;
        }

    }
}
