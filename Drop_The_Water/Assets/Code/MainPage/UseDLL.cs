using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using System;
using Instruction;

[Serializable] 
public class Data { 
	public bool execute;
	public int puzzleLines;

	[Serializable] 
	public struct Arraypuzzle {
		public string action;
		public string number1;
		public string number2;
		public string action2;
		//public int number3;
		//public int number4;
	}

	public Arraypuzzle[] puzzle;
}


public class UseDLL : MonoBehaviour
{

	//[DllImport("TestCPPLibrary")]
	//private static extern IntPtr testStringPassing(string toEcho, int size);

	public Data data = new Data();

	public static UseDLL instance = null;

	void Awake() {
       if(!instance) {
           instance = this;
       } else
            Destroy(this);
	}

	// Use this for initialization
	void Start()
	{

		using (StreamWriter writer = new StreamWriter("debug.txt", true))
		{
			/*string testEchoString = "test test test test test                                          "
				+ "                                                                 "
				+ "                                                                 "
				+ "                                                                 "
				+ "                                                                 "
				+ "                                                                 ";

			writer.WriteLine("before:" + testEchoString);

			IntPtr echoedStringPtr = testStringPassing(testEchoString, testEchoString.Length);

			String echoed = Marshal.PtrToStringAnsi(echoedStringPtr);

			writer.WriteLine("after:"+ echoed);*/

			string echoed = @"{
            	""execute"": false,
            	""puzzleLines"": 2,
            	""puzzle"": [
            		{
                		""action"": ""start"",
                		""number1"": ""0"",
                		""number2"": ""0""
               		},
               		{
                		""action"": ""start"",
                		""number1"": ""0"",
                		""number2"": ""0""
               		}
            	]
         	}";

			data = JsonUtility.FromJson<Data>(echoed);

			Debug.Log ("UseDll excute : "+data.execute);
			Debug.Log ("UseDll puzzleLines : "+data.puzzleLines);
			Debug.Log ("UseDll 1 action1 : "+data.puzzle[0].action);
			Debug.Log ("UseDll 1 number1 : "+data.puzzle[0].number1);
			Debug.Log ("UseDll 1 number2 : "+data.puzzle[0].number2);
			Debug.Log ("UseDll 2 action1 : "+data.puzzle[1].action2);
			//Debug.Log ("UseDll 2 number1 : "+data.puzzle[1].number3);
			//Debug.Log ("UseDll 2 number2 : "+data.puzzle[1].number4);
		}
		/* */

	}

	// Update is called once per frame
	void Update()
	{
		using (StreamWriter writer = new StreamWriter("debug.txt", true))
		{


			/*string testEchoString = "test test test test test                                          "
			   + "                                                                 "
			   + "                                                                 ";

			 writer.WriteLine("before:" + testEchoString);

			 IntPtr echoedStringPtr = testStringPassing(testEchoString, testEchoString.Length);

			 String echoed = Marshal.PtrToStringAnsi(echoedStringPtr);

		 	writer.WriteLine("after:" + echoed);*/

			/*string echoed = @"{
          		""execute"": true,
         		""puzzleLines"": 2,
          		""puzzle"": [
          	    	{
           	      	 ""action"": ""add"",
           	     	  ""number1"": ""4"",
           	     	  ""number2"": ""5""
           	    	},
           	    	{
            			""action"": ""sub"",
            		    ""number1"": ""1"",
             		    ""number2"": ""2""
               		}
           		]
        	}";*/

			//JsonUtility.FromJsonOverwrite(echoed, data);

			string echoed;

        	switch(Resource.stage_add){
            	case 1 :
                    echoed = @"{
                        ""execute"": true,
                        ""puzzleLines"": 2,
                        ""puzzle"": [
                        	{
                            	""action"": ""add"",
                            	""number1"": ""1"",
                            	""number2"": ""2""
                        	},
                            {
                            	""action"": ""minus"",
                            	""number1"": ""1"",
                            	""number2"": ""2""
                        	}
                        ]
                    }";

		            JsonUtility.FromJsonOverwrite(echoed, data);
                    break;

                case 2 :
                    echoed = @"{
                        ""execute"": true,
                        ""puzzleLines"": 2,
                        ""puzzle"": [
                        	{
                            	""action"": ""add"",
                            	""number1"": ""2"",
                            	""number2"": ""none""
                        	},
                            {
                            	""action"": ""minus"",
                            	""number1"": ""1"",
                            	""number2"": ""4""
                            }
                        ]
                    }";

		            JsonUtility.FromJsonOverwrite(echoed, data);
                    break;

                default :
                    break;
             
        	}
		}
	}
}