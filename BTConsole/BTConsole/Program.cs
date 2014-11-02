using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using Microsoft;
using BehaviorLibrary;
using BehaviorLibrary.Components;
using BehaviorLibrary.Components.Actions;
using BehaviorLibrary.Components.Composites;
using BehaviorLibrary.Components.Conditionals;
using BehaviorLibrary.Components.Decorators;
using BehaviorLibrary.Components.Utility;
namespace BTConsole
{
	class MainClass
	{
		public bool func1(bool val){
			if (val)
				return true;
			else
				return false;
		}
		public static void Main (string[] args)
		{
//			bool walkable = true;
//			bool openable = true;
//			bool locked = false;
//			bool closeable = true;
//
//
//			Conditional walk = new Conditional (delegate() {
//				if (walkable)
//					return true;
//				else
//					return false;
//			});
//			Conditional open = new Conditional (delegate() {
//				if (openable)
//					return true;
//				else
//					return false;
//			});
//			Conditional lockedd = new Conditional (delegate() {
//				if (locked)
//					return true;
//				else
//					return false;
//			});
//			Conditional close = new Conditional (delegate() {
//				if (closeable)
//					return true;
//				else
//					return false;
//			});
//
//			BehaviorAction WalkToDoor = new BehaviorAction (delegate(){
//				if(walk.Behave().ToString()=="Success"){
//					Console.WriteLine("walk to door success");
//					return BehaviorReturnCode.Success;
//				}else{
//					Console.WriteLine("walk to door failure");
//					return BehaviorReturnCode.Failure;
//				}});
//
//			BehaviorAction OpenDoor = new BehaviorAction(delegate(){
//				if(open.Behave().ToString()=="Success"){
//					//Console.WriteLine("open door success");
//					return BehaviorReturnCode.Success;
//				}else{
//					//Console.WriteLine("open door failure");
//					return BehaviorReturnCode.Failure;
//				}
//			});
//			BehaviorAction UnlockDoor = new BehaviorAction(delegate(){
//				if(lockedd.Behave().ToString()=="Success"){
//					//Console.WriteLine("unlock door success");
//					return BehaviorReturnCode.Success;
//				}else{
//					//Console.WriteLine("unlock door failure");
//					return BehaviorReturnCode.Failure;
//				}
//			});
//			//BehaviorAction OpenDoor = new BehaviorAction(delegate(){});
//			BehaviorAction WalkThroughDoor = new BehaviorAction(delegate(){
//				if(walk.Behave().ToString()=="Success"){
//					Console.WriteLine("walk through door success");
//					return BehaviorReturnCode.Success;
//				}else{
//					Console.WriteLine("walk through door failure");
//					return BehaviorReturnCode.Failure;
//				}
//			});
//			BehaviorAction CloseDoor = new BehaviorAction(delegate(){
//				if(close.Behave().ToString()=="Success"){
//					Console.WriteLine("close door success and finish");
//					return BehaviorReturnCode.Success;
//				}else{
//					Console.WriteLine("close door failure");
//					return BehaviorReturnCode.Failure;
//				}
//			});
//
//			BehaviorAction sequence2 = new BehaviorAction (delegate() {
//				var temp = new StatefulSequence (UnlockDoor, OpenDoor);
//				return temp.Behave ();
//			});
//
//			BehaviorAction selector1 = new BehaviorAction(delegate(){
//				var selector = new StatefulSelector(sequence2, OpenDoor);
//				return selector.Behave();
//			});
//
//
//			var test = new StatefulSequence (WalkToDoor, selector1, WalkThroughDoor, CloseDoor);
//			//Console.WriteLine (test.Behave());
//			if (test.Behave ().ToString()=="Success") {
//				Console.WriteLine ("Able to walk out");
//			}
//			//System.Console.WriteLine (test.Behave ());

			bool cold = false;
			bool sneeze = false;
			bool fever = true;
			bool tired = true;
			bool headache = true;
			Conditional tooCold = new Conditional (delegate() {
				if(cold) return true;
				else return false;
			});
			Conditional tooSneeze = new Conditional (delegate() {
				if(sneeze) return true;
				else return false;
			});
			Conditional tooFever = new Conditional (delegate() {
				if(fever) return true;
				else return false;
			});
			Conditional tooTired = new Conditional (delegate() {
				if(tired) return true;
				else return false;
			});
			Conditional tooHeadache = new Conditional (delegate() {
				if(headache) return true;
				else return false;
			});
			BehaviorAction areCold = new BehaviorAction (delegate(){
				if(tooCold.Behave().ToString()=="Success"){
					Console.WriteLine("He is cold");
					return BehaviorReturnCode.Success;
				}else{
					Console.WriteLine("He is not cold");
					return BehaviorReturnCode.Failure;
			}});
			BehaviorAction areSneeze = new BehaviorAction (delegate(){
				if(tooSneeze.Behave().ToString()=="Success"){
					Console.WriteLine("He sneezes");
					return BehaviorReturnCode.Success;
				}else{
					Console.WriteLine("He does not sneeze");
					return BehaviorReturnCode.Failure;
				}});
			BehaviorAction areFever = new BehaviorAction (delegate(){
				if(tooFever.Behave().ToString()=="Success"){
					Console.WriteLine("He has a fever");
					return BehaviorReturnCode.Success;
				}else{
					Console.WriteLine("He has no fever");
					return BehaviorReturnCode.Failure;
				}});
			BehaviorAction areTired = new BehaviorAction (delegate(){
				if(tooTired.Behave().ToString()=="Success"){
					Console.WriteLine("He is tired");
					return BehaviorReturnCode.Success;
				}else{
					Console.WriteLine("He is not tired");
					return BehaviorReturnCode.Failure;
				}});
			BehaviorAction areHeadache = new BehaviorAction (delegate(){
				if(tooHeadache.Behave().ToString()=="Success"){
					Console.WriteLine("He has Headache");
					return BehaviorReturnCode.Success;
				}else{
					Console.WriteLine("He has no Headache");
					return BehaviorReturnCode.Failure;
				}});
			Sequence sequencer1 = new Sequence (areCold, areSneeze);
			Sequence sequencer2 = new Sequence (areFever, areCold);
			Selector selector2 = new Selector (areTired, areHeadache);
			Selector selector1 = new Selector (sequencer1, sequencer2, selector2);
			RootSelector root = new RootSelector (delegate() {return 0;}, selector1);
			if (root.Behave ().ToString()=="Success") {
				Console.WriteLine ("He is SICK");



//				string[] lines = System.IO.File.ReadAllLines(@"/Users/jaekyuoh/Desktop/GT/Research/BTConsole/BTConsole/prescription.txt");
//
//				// Display the file contents by using a foreach loop.
//				System.Console.WriteLine("Contents of prescription.txt = ");
//				foreach (string line in lines)
//				{
//					// Use a tab to indent each line of the file.
//					Console.WriteLine("\t" + line);
//				}
				int counter = 0;
				string line;

				// Read the file and display it line by line.
				System.IO.StreamReader file = 
					new System.IO.StreamReader(@"/Users/jaekyuoh/Desktop/GT/Research/BTConsole/BTConsole/prescription.txt");
				while((line = file.ReadLine()) != null)
				{
					System.Console.WriteLine (line);
					counter++;
				}

				file.Close();
				System.Console.WriteLine("There were {0} lines.", counter);
				// Suspend the screen.
				System.Console.ReadLine();
			}

		}
	}
}
