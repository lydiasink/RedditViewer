using System;
using System.Collections.Generic;

namespace Sample.Models
{
    public class Folder

    {

        //A way for the user to customize groupings of the items
        private string name;
        private List<Listing> listings;
        private int count;

        public Folder(String name) {
            listings = new List<Listing>();
            this.name = name;
            this.count = 0;
        }

        public string getName() {
            return this.name;
        }
         
        public int getCount() {
            return this.count;
        }

        public void addListing(Listing l) {
            listings.Add(l);
            count++;
        }

        public void removeListing(int index) {
            listings.Remove(listings[index]);
            count--;
        }
    }
}
