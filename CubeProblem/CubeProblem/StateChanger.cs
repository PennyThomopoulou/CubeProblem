﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CubeProblem
{
    class StateChanger
    {
        public bool IsFree(char cube)
        {
            return Program.free.Contains(cube);
        }

        private void RemoveCube(char cube)
        {
            if (IsFree(cube))
            {
                foreach (List<char> chars in Program.on)
                {
                    if (chars.Contains(cube))
                        chars.Remove(cube);
                    if (chars.Count == 1)
                    {
                        Program.free.Add(chars[0]);
                        chars.Clear();
                    }
                }
                Program.onTable.Remove(cube);
            }
        }

        public void MoveCube(char cube, char destination)
        {
            if (IsFree(cube) && IsFree(destination))
            {   

                RemoveCube(cube);

                bool wasPlaced = false;
                    foreach (List<char> chars in Program.on)
                    {
                        if (chars.Contains(destination))
                        {
                            wasPlaced = true;
                            chars.Add(cube);
                        }
                    }
                    if (!wasPlaced && IsFree(destination))
                    {
                        wasPlaced = true;
                        List<char> pair = new List<char>();
                        pair.Add(destination);
                        pair.Add(cube);
                        Program.on.Add(pair);
                    }
                    if (wasPlaced)
                    {
                        Program.free.Remove(destination);
                    }
                }

            else
            {
                Console.WriteLine($"Cube {cube} could not be placed on cube {destination}");
            }
        }

        public void MoveCube(char cube)
        {
            if (IsFree(cube))
            {
                RemoveCube(cube);

                Program.onTable.Add(cube);
            }
            else
            {
                Console.WriteLine($"Cube {cube} could not be placed on the table");
            }
        }
    }
}
