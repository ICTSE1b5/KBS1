using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace KBS1.model
{

    public abstract class GameObject
    {
        public enum SpeedEffects
        {
            SLOW_1 = -2,
            SLOW_2 = -4,
            FAST_1 = 2,
            FAST_2 = 4
        }
        public enum ObjectType
        {
            BORDER,
            PLAYER,
            ENEMY,
            WALL,
            GOAL,
            EFFECT
        }
        public enum ObjectProperties
        {
            Position_X,
            Position_Y,
            Speed_X,
            Speed_Y,
            Width,
            Height,
            Damage,
            Health,
            Type,
            Image
        }
        public enum Direction
        {
            NORTH,
            WEST,
            SOUTH,
            EAST,
            NONE
        }
        public enum ObjectSide
        {
            TOP,
            BOTTOM,
            LEFT,
            RIGHT
        }


        // Properties that all game objects have
        protected int Position_X;
        protected int Position_Y;

        protected int Width;
        protected int Height;

        protected int Speed_X;
        protected int Speed_Y;

        protected int Damage;
        protected int Health;

        protected bool isSolid;


        //An int to make sure an objects stops at the position of impact instead of moving throught another object
        private int speedCollisionDebuff_vertical = 0;
        private int speedCollisionDebuff_horizontal = 0;

        //Holds all the objects that this object has a collision with
        public List<GameObject> currentCollisionObjectsList;

        //Holds all the Effects currently active
        private List<SpeedEffects> currentSpeedEffectList;
        //Uses this number to effect the speed of the object
        private int speedEffectNumber;

        //Holds the horizontal and vertical direction
        protected Direction horizontalDirection;
        protected Direction verticalDirection;

        //A safeguard to make sure the GiveAllTargets method is used before the Activate_AI method
        protected bool AI_CollisionSafeGuard;
        //A boolean to keep track if the object is dead
        protected bool alive;

        public ObjectType Type { get; set; }

        //Other???
        protected Form1 game_Form;


        //All images
        protected Image imageNorthWest = Properties.Resources.imagenotfound;
        protected Image imageNorth = Properties.Resources.imagenotfound;
        protected Image imageNorthEast = Properties.Resources.imagenotfound;
        //
        protected Image imageWest = Properties.Resources.imagenotfound;
        protected Image imageIdle = Properties.Resources.imagenotfound;
        protected Image imageEast = Properties.Resources.imagenotfound;
        //
        protected Image imageSouthWest = Properties.Resources.imagenotfound;
        protected Image imageSouth = Properties.Resources.imagenotfound;
        protected Image imageSouthEast = Properties.Resources.imagenotfound;
        
        public Image image { get; set; }
        public string description { get; set; }

        protected GameObject( int pos_x, int pos_y, int width, int height, int speed_x, int speed_y, int damage, int health, Form1 form)
        {
            Position_X = pos_x;
            Position_Y = pos_y;

            Width = width;
            Height = height;

            Speed_X = speed_x;
            Speed_Y = speed_y;

            Damage = damage;
            Health = health;

            game_Form = form;


            horizontalDirection = Direction.NONE;
            verticalDirection = Direction.NONE;

            alive = true;
            isSolid = true;

            currentCollisionObjectsList = new List<GameObject>();
            currentSpeedEffectList = new List<SpeedEffects>();
            setupImages();
        }

        protected abstract void setupImages();
        /* EXAMPLE
        imageNorthWest = Properties.Resources.;
        imageNorth = Properties.Resources.;
        imageNorthEast = Properties.Resources.;
        
        imageWest = Properties.Resources.;
        imageIdle = Properties.Resources.;
        imageEast = Properties.Resources.;
        
        imageSouthWest = Properties.Resources.;
        imageSouth = Properties.Resources.;
        imageSouthEast = Properties.Resources.;
        */



        //Movement has been split to horizontal and vertical, to make movement easier
        public void Move()
        {
            speedEffectNumber = getSpeedBuffNumber();

            MoveVerticaly();
            MoveHorizontaly();

            //Remove all the movement effects currently active so that after the object moved, the stats return to normal and the object will move the same speed again.
            currentSpeedEffectList.RemoveAll(ob => true);
            speedEffectNumber = 0;


            //Failsave if the player moves out of bounds
            if(pos_y < 0) //Top
            {
                Position_Y = 0;
            }
            if (pos_y > game_Form.getHeightOfGame() - Height) //Bottom
            {
                Position_Y = game_Form.getHeightOfGame() - Height;
            }
            if (pos_x < 0) //Left
            {
                Position_X = 0;
            }
            if (pos_y > game_Form.getWidthOfGame() - Width) //Right
            {
                Position_X = game_Form.getWidthOfGame() - Width;
            }

        }
        protected virtual void MoveVerticaly()
        {            
            switch (verticalDirection)
            {
                case Direction.NORTH:       //up
                    moveUp();
                    break;
                case Direction.SOUTH:       //down
                    moveDown();
                    break;
                default:                    //Direction = NONE
                    break;
            }
        }
        protected virtual void MoveHorizontaly()
        {
            switch (horizontalDirection)
            {
                case Direction.WEST:       //left
                    moveLeft();
                    break;
                case Direction.EAST:       //right
                    moveRight();
                    break;
                default:                    //Direction = NONE
                    break;
            }
        }
        #region moveUpDownLeftRight
        private void moveUp()
        {
            //PROBLEM : NEEDS FIX --> MOVEMENT ALSO NEEDS TO BE IMPLEMENTED IN THE 'COLLISION DETECTION OF OBJECT PATH' AND 'GET VITUAL RECTANGLE OF VIRTUAL MOVEMENT'!!
            //CAN BE FIXED EASILY BY DISABLEING PATH COLLISION AND ALWAYS USING RECTANGLE COLLISION, AND JUST FIXING THE VIRTUAL RECTANGLES
            int movement = Speed_Y - speedCollisionDebuff_vertical;
            if(!((movement + speedEffectNumber) < 0))
            {
                movement += speedEffectNumber;
            }

            Position_Y -= movement;
            speedCollisionDebuff_vertical = 0;
            
        }
        private void moveDown()
        {
            int movement = Speed_Y - speedCollisionDebuff_vertical;
            if (!((movement + speedEffectNumber) < 0))
            {
                movement += speedEffectNumber;
            }

            Position_Y += movement;
            speedCollisionDebuff_vertical = 0;
        }
        private void moveLeft()
        {
            int movement = Speed_X - speedCollisionDebuff_horizontal;
            if (!((movement + speedEffectNumber) < 0))
            {
                movement += speedEffectNumber;
            }

            Position_X -= movement;
            speedCollisionDebuff_horizontal = 0;
        }
        private void moveRight()
        {
            int movement = Speed_X - speedCollisionDebuff_horizontal;
            if (!((movement + speedEffectNumber) < 0))
            {
                movement += speedEffectNumber;
            }

            Position_X += movement;
            speedCollisionDebuff_horizontal = 0;
        }
        #endregion

        //Public Activate command, and abstract AI command for sub classes to implement
        public void ActivateAI()
        {
            //Makes sure the Give All Targets method has been used
            if (AI_CollisionSafeGuard)
            {
                System.Windows.Forms.MessageBox.Show("PLEASE USE THE GIVE-ALL-TARGETS-ME-AS-TARGET METHOD BEFORE THE ACTIVATE-AI METHOD!!!", "PLEASE");
            }
            else
            {
                //Makes sure there are no duplicates in the list
                currentCollisionObjectsList = currentCollisionObjectsList.Distinct().ToList();
                //And activates the AI
                AI();

                //The removes all collision objects from the list
                currentCollisionObjectsList.RemoveAll(ob => true);

                //And activate the safeguard again.
                AI_CollisionSafeGuard = true;
            }
        }
        protected abstract void AI();
        /* EXAMPLE
        foreach(GameObject ob in currentCollisionObjectsList)
            {
                switch(ob.Type)
                {
                    case ObjectType.PLAYER:
                        //DO STUFF
                        break;
                    default:
                        break;
                }

            }
        */
        protected abstract bool CollisionAI(GameObject target); //Give an object to collide with, and return if the collision should stop that type of object. False means that it can pass through.
        /* EXAMPLE
        switch(target.Type)
            {
                case ObjectType.PLAYER:
                    return true;
                default:
                    return true;
            }
        */

        //public Kill command, and abstract OnDeath command for sub classes to implement
        public void Kill()
        {
            alive = false;
            OnDeath();
        }
        protected abstract void OnDeath();

        //Add a target to the collision list
        public void AddCollisionTarget(GameObject target)
        {
            currentCollisionObjectsList.Add(target);
        }
        //Make sure that your target also knows you as a collision target. Even though he can't reach you
        public void GiveAllTargetsMeAsTarget()
        {
            currentCollisionObjectsList.ForEach(ob => ob.AddCollisionTarget(this));

            AI_CollisionSafeGuard = false;
        }



        //Sets the horizontal and vertical direction
        public void setVerticalDirection(Direction direction)
        {
            if (direction == Direction.NORTH || direction == Direction.SOUTH || direction == Direction.NONE)
            {
                verticalDirection = direction;
            }
        }
        public void setHorizontalDirection(Direction direction)
        {
            if (direction == Direction.EAST || direction == Direction.WEST || direction == Direction.NONE)
            {
                horizontalDirection = direction;
            }
        }
        public Direction getHorizontalDirection()
        {
            return horizontalDirection;
        }
        public Direction getVerticalDirection()
        {
            return verticalDirection;
        }
        //Gets the distance between two objects
        public int getVerticalDistanceToObject(GameObject target)
        {
            //Makes a return value
            int returnValue_Distance = 0;
            //Checks the direction to calculate the correct distance
            switch (verticalDirection)
            {
                //This easy calculation calculates the distance to a target in FRONT of the target. It cannot calculate the correct distance to an object behind it.
                //Take that in mind then calculating the distance!
                case Direction.NORTH:
                    returnValue_Distance = ((target.Position_Y + target.Height) - this.Position_Y);
                    break;
                case Direction.SOUTH:
                    returnValue_Distance = ((this.Position_Y + this.Height) - target.Position_Y);
                    break;
                default:
                    returnValue_Distance = this.Position_Y - target.Position_Y;
                    break;
            }
            //If the distance is negative, this is an easy fix
            if (returnValue_Distance < 0)
            {
                returnValue_Distance *= -1;
            }
            return returnValue_Distance;
        }
        public int getHorizontalDistanceToObject(GameObject target)
        {
            int returnValue_Distance = 0;
            switch (horizontalDirection)
            {
                case Direction.WEST:
                    returnValue_Distance = ((target.Position_X + target.Width) - this.Position_X);
                    break;
                case Direction.EAST:
                    returnValue_Distance = ((this.Position_X + this.Width) - target.Position_X);
                    break;
                default:
                    returnValue_Distance = this.Position_X - target.Position_X;
                    break;
            }
            if (returnValue_Distance < 0)
            {
                returnValue_Distance *= -1;
            }
            return returnValue_Distance;
        }

        //Returns the X or Y value of the side that has been requested
        //Left and Right have an X value
        //While Top and Bottom have a Y value
        public bool isAlive
        {
            get { return alive; }
        }
        public bool isSolidious()
        {
            return isSolid;
        }
        public int getObjectSide(ObjectSide side)
        {
            switch (side)
            {
                case ObjectSide.TOP:
                    return Position_Y; //The pos_y is on the top left side of the sprite, so the top can give pos_y back
                case ObjectSide.BOTTOM:
                    return Position_Y + Height; //The bottom is basicly the origin point plus the height of the object
                case ObjectSide.LEFT:
                    return Position_X; //Same as the top, the pos_x gives the left side of the object
                case ObjectSide.RIGHT:
                    return Position_X + Width; //And lastly the right side is the pos_x with the width of the object
                default:
                    return Position_Y;   //Returns the default top side, which is a Y value
            }
        }

        //Get the properties       
        #region Object Properties Getter
        public int pos_x
        {
            get { return Position_X; }
        }
        public int pos_y
        {
            get { return Position_Y; }
        }
        public int width
        {
            get { return Width; }
        }
        public int height
        {
            get { return Height; }
        }
        public int speed_X
        {
            get { return Speed_X; }
        }
        public int speed_Y
        {
            get { return Speed_Y; }
        }
        public int DMG
        {
            get { return Damage; }
        }
        public int HP
        {
            get { return Health; }
        }
        public Image getObjectImage()
        {
            string vertical = "";
            string horizontal = "";

            switch (verticalDirection)
            {
                case Direction.NORTH:
                    horizontal += "North";
                    break;
                case Direction.SOUTH:
                    horizontal += "South";
                    break;
                default:
                    break;
            }
            switch (horizontalDirection)
            {
                case Direction.EAST:
                    horizontal += "East";
                    break;
                case Direction.WEST:
                    horizontal += "West";
                    break;
                default:
                    break;
            }
            
            switch(vertical + horizontal)
            {
                case "North":
                    return imageNorth;
                case "NorthEast":
                    return imageNorthEast;
                case "NorthWest":
                    return imageNorthWest;

                case "South":
                    return imageSouth;
                case "SouthEast":
                    return imageSouthEast;
                case "SouthWest":
                    return imageSouthWest;

                case "East":
                    return imageEast;
                case "West":
                    return imageWest;
                default:
                    return imageIdle;
            }
        }
        #endregion Object Properties Getter

        //A property to return a rectangle object of the GameObject and to give virutal rectangles that give back a rectangle that simulates movement
        public Rectangle ObjectRectangle
        {
            get { return new Rectangle(Position_X, Position_Y, Width, Height); }
        }
        public Rectangle VirutalHorizontalRectangle
        {
            get
            {
                int speedBuffX = getSpeedBuffNumber();
                if (Speed_X + speedBuffX < 0)
                {
                    speedBuffX = Speed_X * -1;
                }

                int virutalSpeed = 0;
                switch (horizontalDirection)
                {
                    case Direction.EAST:
                        virutalSpeed += Speed_X + speedBuffX;
                        break;
                    case Direction.WEST:
                        virutalSpeed -= Speed_X + speedBuffX;
                        break;
                    default:
                        break;
                }
                return new Rectangle(Position_X + virutalSpeed, Position_Y, Width, Height);
            }
        }
        public Rectangle VirutalVerticalRectangle
        {
            get
            {
                int speedBuffY = getSpeedBuffNumber();
                if (Speed_Y + speedBuffY < 0)
                {
                    speedBuffY = Speed_Y * -1;
                }

                int virutalSpeed = 0;
                switch (verticalDirection)
                {
                    case Direction.SOUTH:
                        virutalSpeed += Speed_Y + speedBuffY;
                        break;
                    case Direction.NORTH:
                        virutalSpeed -= Speed_Y + speedBuffY;
                        break;
                    default:
                        break;
                }
                return new Rectangle(Position_X, Position_Y + virutalSpeed, Width, Height);
            }
        }
        public Rectangle VirtualRectangle
        {
            get
            {
                int speedBuffX = getSpeedBuffNumber(); 
                int speedBuffY = getSpeedBuffNumber();
                if (Speed_X + speedBuffX < 0)
                {
                    speedBuffX = Speed_X*-1;
                }
                if (Speed_Y + speedBuffY < 0)
                {
                    speedBuffY = Speed_Y * -1;
                }

                int virutalSpeed_Y = 0;
                int virutalSpeed_X = 0;

                switch (verticalDirection)
                {
                    case Direction.SOUTH:
                        virutalSpeed_Y += Speed_Y + speedBuffY;
                        break;
                    case Direction.NORTH:
                        virutalSpeed_Y -= Speed_Y + speedBuffY;
                        break;
                    default:
                        break;
                }
                switch (horizontalDirection)
                {
                    case Direction.EAST:
                        virutalSpeed_X += Speed_X + speedBuffX;
                        break;
                    case Direction.WEST:
                        virutalSpeed_X -= Speed_X + speedBuffX;
                        break;
                    default:
                        break;
                }

                return new Rectangle(Position_X + virutalSpeed_X, Position_Y + virutalSpeed_Y, Width, Height);
            }
        }

        //Collision debuff        
        public void horizontalCollisionWithObject(GameObject target)
        {
            int debuff = 0;
            if(CollisionAI(target))       //TODO
            {
                debuff = Speed_X - getHorizontalDistanceToObject(target);
            }
            else
            {
                //MessageBox.Show("YAY");
            }
            

            //checks to see if the debuff is greater than the current debuff and then applies it, and sets the target to the collision target for the AI
            if (speedCollisionDebuff_horizontal < debuff)
            {
                speedCollisionDebuff_horizontal = debuff;
                currentCollisionObjectsList.Add(target);
            }
            //makes sure that the debuff is not negative or more than the speed 
            if (speedCollisionDebuff_horizontal < 0)
            {
                speedCollisionDebuff_horizontal = 0;
            }
            if (speedCollisionDebuff_horizontal > Speed_X)
            {
                speedCollisionDebuff_horizontal = Speed_X;
            }
        }
        public void verticalCollisionWithObject(GameObject target)
        {
            int debuff = 0;
            if (CollisionAI(target))        //TODO
            {
                debuff = Speed_Y - getVerticalDistanceToObject(target);
            }
            
            

            //checks to see if the debuff is greater than the current debuff and then applies it, and sets the target to the collision target for the AI
            if (speedCollisionDebuff_vertical < debuff)
            {
                speedCollisionDebuff_vertical = debuff;
                currentCollisionObjectsList.Add(target);
            }
            //makes sure that the debuff is not negative or more than the speed 
            if (speedCollisionDebuff_vertical < 0)
            {
                speedCollisionDebuff_vertical = 0;
            }
            if (speedCollisionDebuff_vertical > Speed_Y)
            {
                speedCollisionDebuff_vertical = Speed_Y;
            }
        }

        //Effect Giving
        public void giveSpeedEffect(SpeedEffects effect)
        {
            currentSpeedEffectList.Add(effect);
        }
        private int getSpeedBuffNumber()
        {
            int speedBuff = 0;
            int lowest = 0;
            int highest = 0;
            List<int> buffList = new List<int>();

            //Goes through each effect in the list to add get the speed (de)buff number
            foreach (SpeedEffects currentEffect in currentSpeedEffectList)
            {
                //Get the lowest(negative) and highest(positive)
                buffList.Add((int)currentEffect);
            }

            //If the list has 2 or more items, calculate the numbers
            if(buffList.Count >= 2)
            {
                //Tries to get the lowest negative number
                if ((int)buffList.Min() < 0)
                {
                    lowest = buffList.Min();
                }
            
                //Tries to get the highest positive number
                if ((int)buffList.Max() > 0)
                {
                    highest = buffList.Max();
                }
            }
            else if(buffList.Count == 1)
            {
                return buffList[0];
            }
            else
            {
                return 0;
            }


            //Adds the negative with the positive and return the end result
            speedBuff = highest + lowest;
            //And return the number
            return speedBuff;
        }


    }
}