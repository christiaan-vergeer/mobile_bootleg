using Microsoft.VisualStudio.TestTools.UnitTesting;
using mobile_test.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace mobile_test.TestData
{
    [TestClass]
    public class UnitTests : TestBase
    {
        [TestMethod]
        public async Task Swipe_EmptyObservableCollection_ShouldNotInvoke()
        {
            var cardPersons = new ObservableCollection<string>();
            var swipeCardView = new SwipeCardView();
            var swipeCardDirection = SwipeCardDirection.None;

            swipeCardView.PersonsSource = cardPersons;
            swipeCardView.Swiped += (sender, args) => { swipeCardDirection = args.Direction; };

            await swipeCardView.InvokeSwipe(SwipeCardDirection.Right);

            Assert.AreEqual(swipeCardDirection, SwipeCardDirection.None);
            Assert.AreEqual(swipeCardView.PersonsSource.Count, 0);
        }

        [TestMethod]
        public async Task Swipe_ObservableCollection_UpdatesTopItem()
        {
            var swipeCardView = new SwipeCardView
            {
                PersonTemplate = new DataTemplate(() =>
                {
                    var stackLayout = new StackLayout();
                    var label = new Label();
                    label.SetBinding(Label.TextProperty, ".");
                    stackLayout.Children.Add(label);

                    return stackLayout;
                })
            };

            swipeCardView.PersonsSource = new ObservableCollection<string>() { "Person1", "Person2" };

            var swipeCardDirection = SwipeCardDirection.None;
            swipeCardView.Swiped += (sender, args) => { swipeCardDirection = args.Direction; };
            var initialTopPerson = swipeCardView.TopPerson;

            await swipeCardView.InvokeSwipe(SwipeCardDirection.Right);

            var afterSwipeTopPerson = swipeCardView.TopPerson;

            Assert.AreEqual(swipeCardDirection, SwipeCardDirection.Right);
            Assert.AreEqual(swipeCardView.PersonsSource.Count, 2);
            Assert.AreNotEqual(initialTopPerson, afterSwipeTopPerson);
            Assert.AreEqual(initialTopPerson, "Item1");
            Assert.AreEqual(afterSwipeTopPerson, "Item2");
        }

        [TestMethod]
        public async Task Swipe_SetObservableCollectionTwice()
        {
            var swipeCardView = new SwipeCardView
            {
                PersonTemplate = new DataTemplate(() =>
                {
                    var stackLayout = new StackLayout();
                    var label = new Label();
                    label.SetBinding(Label.TextProperty, ".");
                    stackLayout.Children.Add(label);

                    return stackLayout;
                })
            };

            swipeCardView.PersonsSource = new ObservableCollection<string>() { "Item1", "Item2" };
            swipeCardView.PersonsSource = new ObservableCollection<string>() { "Item3", "Item4" };

            var swipeCardDirection = SwipeCardDirection.None;
            swipeCardView.Swiped += (sender, args) => { swipeCardDirection = args.Direction; };
            var initialTopItem = swipeCardView.TopPerson;

            await swipeCardView.InvokeSwipe(SwipeCardDirection.Right);

            var afterSwipeTopItem = swipeCardView.TopPerson;

            Assert.AreEqual(swipeCardDirection, SwipeCardDirection.Right);
            Assert.AreEqual(swipeCardView.PersonsSource.Count, 2);
            Assert.AreNotEqual(initialTopItem, afterSwipeTopItem);
            Assert.AreEqual(initialTopItem, "Item3");
            Assert.AreEqual(afterSwipeTopItem, "Item4");
        }
    }
}
