﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KBS1.model;
using System.Drawing;

namespace KBS1.controller
{
    class GameController
    {
        private Form game_Form;
        private GameLoop game_Loop;
        private List<GameObject> game_ObjectList;
        public enum CollisionCalculationMethod
        {
            ANY,
            RECTANGLE_CALCULATION,
            OBJECT_PATH_CALCULATION
        }
        private CollisionCalculationMethod method = CollisionCalculationMethod.ANY;

        public GameController(Form form, GameLoop loop)
        {
            game_Form = form;
            game_Loop = loop;
            game_ObjectList = new List<GameObject>();
            //needs extra initialization items
        }

        public void Update(List<GameObject> list)
        {
            game_ObjectList = list;

            foreach (GameObject ob in game_ObjectList)
            {
                //Compares the current object against all of the other objects that are in the list
                //2 Ways to do it. Don't know yet which one is better
                bool test = false;
                if (test)
                {
                    var onlyOtherObjects =
                        from value in game_ObjectList
                        where value != ob
                        select value;

                    onlyOtherObjects.ToList().ForEach(ob2 => TestForCollision(ob, ob2));
                }
                else
                {
                    foreach (GameObject ob2 in game_ObjectList)
                    {
                        //Tests if the current object is not the target object (that would cuase problems)
                        if (!ob.Equals(ob2))
                        {
                            //Test for a collision, if there is a collision, call the collide method  
                            TestForCollision(ob, ob2);
                        }
                    }
                }

                //Moves the object one at a time, so that every object has a fair chance to move and collide
                ob.Move();
            }


            //In the end call the repaint method on the form
            game_Form.Invalidate();
            Application.DoEvents();

            //After the update loop, all the AI of every object so that every object can move before taking action on a collision.
            game_ObjectList.ForEach(ob => ob.GiveAllTargetsMeAsTarget());
            game_ObjectList.ForEach(ob => ob.ActivateAI());

            //If the object is dead at the end of the update, remove it from the list
            game_ObjectList.RemoveAll(ob => !ob.isAlive);
        }


        #region CollisionTesting
        //Tests if an object is about to collide with another object and acts on that
        private void TestForCollision(GameObject subject, GameObject target)
        {
            //If the speed is greater than that the objects size, calculate with the Object Path otherwise, if the object has a low speed, calculate with the Rectangle Calculation
            if (subject.speed_X > subject.width || subject.speed_Y > subject.height)
            {
                method = CollisionCalculationMethod.OBJECT_PATH_CALCULATION;
            }
            else
            {
                method = CollisionCalculationMethod.RECTANGLE_CALCULATION;
            }


            //Selects the faster method, which can cause warpinig issues, or the slower method, which calculates the collision path even with fast moving objects
            if (method == CollisionCalculationMethod.RECTANGLE_CALCULATION)
            {
                if(subject.VirtualRectangle.IntersectsWith(target.ObjectRectangle))
                {
                    CollidesWith(subject, target, true);
                    CollidesWith(subject, target, false);
                }
            }
            else if (method == CollisionCalculationMethod.OBJECT_PATH_CALCULATION)
            {
                //Tests on horizontaly and verticaly beside the subject
                bool Vertical = TestVerticalCollision(subject, target, false);
                bool Horizontal = TestHorizontalCollision(subject, target, false);

                //Seperate if statements, to test all the possible collisions on the axis
                //And if there was no collision on an axis, make a virtual move and test if the other axis gets a collision
                if (!Vertical)
                {
                    //###MessageBox.Show("Testing virtual collision for the X-axis. (Virtually moved Verticaly)");
                    if (TestHorizontalCollision(subject, target, true) == false)
                    {
                        //###MessageBox.Show("Test completed: No target collision on X-axis");
                        Horizontal = false;
                    }
                    else
                    {
                        //###MessageBox.Show("Collision after test on X-Axis");
                    }
                }
                if (!Horizontal)
                {
                    //###MessageBox.Show("Testing virtual collision for the Y-axis. (Virtually moved Horizontaly)");
                    if (TestVerticalCollision(subject, target, true) == false)
                    {
                        //###MessageBox.Show("Test completed: No target collision on Y-axis");
                        Vertical = false;
                    }
                    else
                    {
                        //###MessageBox.Show("Collision after test on Y-Axis");
                    }
                }

                //After the original collision testing ANd the virtual collision test, look to see if there was a collision on a certain axis
                //Collision on Y
                if (Vertical)
                {
                    //MessageBox.Show("Collision! Vertical");
                    CollidesWith(subject, target, true);
                }
                //Collision on X
                if (Horizontal)
                {
                    //MessageBox.Show("Collision! Horizontal");
                    CollidesWith(subject, target, false);
                }

            }
        }


        //The Object path calculation, it calculates the path towards the target object and calculates if it collides with the target
        //Slower but more accurate
        #region ObjectPathCalculation
        //This has two boolean methods because of the virtual collision tests that accur, 
        //  they need the objects to calculate the collision and a boolean to know if this is a simulated collision test

        private bool TestVerticalCollision(GameObject subject, GameObject target, bool isVirtual)
        {
            //Calculate the distance between the two rectangles

            //If the subject doesn't have a vertical movement, there would be no reason to test vertical collision
            if (subject.getVerticalDirection() == GameObject.Direction.NONE)
            {
                return false;
            }


            //So compare the Y distance            
            bool speedGreaterThanDistance = (/*distance vs speed*/  subject.getVerticalDistanceToObject(target) < subject.speed_Y);


            //if the speed is not greater than the distance, there will be no collision and false can be returned
            //if the speed is greater than the distance, the X sides will be compared to see if they're on the same course and therefore if a collision might occur
            if (speedGreaterThanDistance == false)
            {
                return false;
            }

            //Gets a rectangle from the subject and the target to easily calculate with the virtual data, if needed.
            Rectangle subjectRectangle;
            Rectangle targetRectangle = target.ObjectRectangle;
            if (isVirtual)
            {
                subjectRectangle = subject.VirutalHorizontalRectangle;
            }
            else
            {
                subjectRectangle = subject.ObjectRectangle;
            }

            //compare x sides
            bool outSideComparison = (subjectRectangle.X < targetRectangle.X + targetRectangle.Width);
            bool innerSideComparison = (subjectRectangle.X + subjectRectangle.Width < targetRectangle.X);
            //and if the inner sides are at the same position, no collision will occur, but instead it will graze past it creating non-slowening friction but no collision
            if (subjectRectangle.X + subjectRectangle.Width == targetRectangle.X)
            {
                innerSideComparison = outSideComparison;
            }
            //If the sides are both higher or both lower that the other side, it will not be in the path and there'll be no collision
            if ((outSideComparison == false && innerSideComparison == false) || (outSideComparison == true && innerSideComparison == true))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool TestHorizontalCollision(GameObject subject, GameObject target, bool isVirtual)
        {
            //If the subject doesn't have a horizontal movement, there would be no reason to test horizontal collision
            if (subject.getHorizontalDirection() == GameObject.Direction.NONE)
            {
                return false;
            }


            //Compare the X distance            
            bool speedGreaterThanDistance = (/*distance vs speed*/  subject.getHorizontalDistanceToObject(target) < subject.speed_X);


            //if the speed is not greater than the distance, there will be no collision and false can be returned
            //if the speed is greater than the distance, the Y sides will be compared to see if they're on the same course and therefore if a collision might occur
            if (speedGreaterThanDistance == false)
            {
                return false;
            }


            Rectangle subjectRectangle;
            Rectangle targetRectangle = target.ObjectRectangle;
            if (isVirtual)
            {
                subjectRectangle = subject.VirutalVerticalRectangle;
            }
            else
            {
                subjectRectangle = subject.ObjectRectangle;
            }

            //compare Y sides
            bool outSideComparison = (subjectRectangle.Y < (targetRectangle.Y + targetRectangle.Height));
            bool innerSideComparison = ((subjectRectangle.Y + subjectRectangle.Height) < targetRectangle.Y);
            //and if the inner sides are at the same position, no collision will occur, but instead it will graze past it creating non-slowening friction but no collision
            if ((subjectRectangle.Y + subjectRectangle.Height) == targetRectangle.Y)
            {
                innerSideComparison = outSideComparison;
            }
            //If the sides are both higher or both lower that the other side, it will not be in the path and there'll be no collision
            if ((outSideComparison == false && innerSideComparison == false) || (outSideComparison == true && innerSideComparison == true))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion ObjectPathCalculation


        //The Rectangle calculation, it calculates if the endpoint of the move method of an object intersects with the position of another object
        //Faster but more prone to warping issues
        #region RectangleCalculation

        //      TODO

        /*
        EASY MODE Collision detection with rectangles:
        BUT: If the speed is greater than the width or height, the object literly warps over the field and will warp 'through' other objects.
        This can be prevented with a more heavy method to calculate the path towards the target object instead of comparing the end location of an object.
        MAYBE: With a boolean this can be switched??

        https://msdn.microsoft.com/en-us/library/y10fyck0%28v=vs.110%29.aspx  
        */
        #endregion RectangleCalculation



        //Method when two objects are going to collide
        private void CollidesWith(GameObject subject, GameObject target, bool isVertical) //isVertical = true --> The Y axis,    isVertical = false --> The X axis
        {
            //Give collision debuff and sets the target to be a collision target in the subject
            if (isVertical)
            {
                subject.verticalCollisionWithObject(target);
            }
            else
            {
                subject.horizontalCollisionWithObject(target);
            }
        }
        #endregion CollisionTesting

    }
}
