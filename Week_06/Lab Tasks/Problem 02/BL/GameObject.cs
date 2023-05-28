using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_02.BL
{
    internal class GameObject
    {
        public char[,] Shape;
        public Point StartingPoint;
        public Boundary Premises;
        public string Direction;
        public int projectileSteps = 0;
        public string directionPatrol = "Right";
        public GameObject()
        {
            this.Shape = new char[1, 3] { { '-', '-', '-' } };
            this.StartingPoint = new Point(0, 0);
            this.Premises = new Boundary();
            this.Direction = "LeftToRight";
        }
        public GameObject(char[,] Shape, Point StartingPoint)
        {
            this.Shape = Shape;
            this.StartingPoint = StartingPoint;
            this.Premises = new Boundary();
            this.Direction = "LeftToRight";
        }
        public GameObject(char[,] Shape, Point StartingPoint, Boundary Premises, string Direction)
        {
            this.Shape = Shape;
            this.StartingPoint = StartingPoint;
            this.Premises = Premises;
            this.Direction = Direction;
        }
        public void Move()
        {
            if (Direction == "LeftToRight")
            {
                moveLeftToRight();
            }
            else if (Direction == "RightToLeft")
            {
                moveRightToLeft();
            }
            else if (Direction == "Diagonal")
            {
                bottomLeftDiagonal();
            }
            else if (Direction == "Projectile")
            {
                if (projectileSteps <= 10)
                {
                    Console.WriteLine(projectileSteps);

                    bottomLeftDiagonal();
                    projectileSteps++;
                }
                else if (projectileSteps >= 10 && projectileSteps <= 20)
                {
                    Console.WriteLine(projectileSteps);

                    moveLeftToRight();
                    projectileSteps++;
                }
                else if (projectileSteps >= 20 && projectileSteps <= 30)
                {
                    Console.WriteLine(projectileSteps);

                    topLeftDiagonal();
                    projectileSteps++;
                }
            }
            else if (Direction == "Patrol")
            {
                if (directionPatrol == "Right")
                {
                    moveLeftToRight();
                    if (StartingPoint.getY() == Premises.getTopRight().getY())
                    {
                        directionPatrol = "Left";
                    }
                }
                else if (directionPatrol == "Left")
                {
                    moveRightToLeft();
                    if (StartingPoint.getY() == Premises.getTopRight().getY())
                    {
                        directionPatrol = "Right";
                    }
                }
            }
        }
        public void moveLeftToRight()
        {
            if (StartingPoint.getY() < Premises.getTopRight().getY())
            {
                int y = StartingPoint.getY();
                y++;
                StartingPoint.setY(y);
            }
        }
        public void moveRightToLeft()
        {
            if (StartingPoint.getY() > Premises.getTopLeft().getY())
            {
                int y = StartingPoint.getY();
                y--;
                StartingPoint.setY(y);
            }
        }
        public void topLeftDiagonal()
        {
            if (StartingPoint.getX() < Premises.getBottomRight().getX() && StartingPoint.getY() < Premises.getBottomRight().getY())
            {
                int x = StartingPoint.getX();
                int y = StartingPoint.getY();
                x++;
                y++;
                StartingPoint.setX(x);
                StartingPoint.setY(y);
            }
        }
        public void bottomRightDiagonal()
        {
            if (StartingPoint.getX() > Premises.getTopLeft().getX() && StartingPoint.getY() > Premises.getTopLeft().getY())
            {
                int x = StartingPoint.getX();
                int y = StartingPoint.getY();
                x--;
                y--;
                StartingPoint.setX(x);
                StartingPoint.setY(y);
            }
        }
        public void bottomLeftDiagonal()
        {
            if (StartingPoint.getX() > Premises.getTopRight().getX() && StartingPoint.getY() < Premises.getTopRight().getY())
            {
                int x = StartingPoint.getX();
                int y = StartingPoint.getY();
                x--;
                y++;
                StartingPoint.setX(x);
                StartingPoint.setY(y);
            }
        }
        public void draw()
        {
            for (int i = 0; i < Shape.GetLength(0); i++)
            {
                for (int j = 0; j < Shape.GetLength(1); j++)
                {
                    Console.SetCursorPosition(StartingPoint.getY() + j, StartingPoint.getX() + i);
                    Console.Write(Shape[i, j]);
                 
                }
            }
            
        }
    }
}
