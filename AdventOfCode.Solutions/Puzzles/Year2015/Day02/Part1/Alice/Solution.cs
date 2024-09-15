﻿using AdventOfCode.Solutions.Library;
using AdventOfCode.Solutions.Library.Metadata;

namespace AdventOfCode.Solutions.Puzzles.Year2015.Day02.Part1.Alice;

public class Solution : BaseSolution
{
    public override SolutionMetadata Metadata => new(Year.Year2015, Day.Day02, Part.Part1, Author.Alice);

    public override Task<string> Solve(string input)
    {
        int totalWrappingPaper = 0;
        string[] lines = input.Split(new[] { '\r', '\n' });
        foreach (string line in lines)
        {
            string[] parts = line.Split('x');
            int l = int.Parse(parts[0]);
            int w = int.Parse(parts[1]);
            int h = int.Parse(parts[2]);

            int wrappingPaperForPresent = CalculateTotalWrappingPaper(l, w, h);
            totalWrappingPaper += wrappingPaperForPresent;
        }

        return Task.FromResult(totalWrappingPaper.ToString());
    }

    public int CalculateSurface(int l, int w, int h)
    {
        return 2 * l * w + 2 * w * h + 2 * h * l;
    }

    public int CalculateSmallSurface(int l, int w, int h)
    {
        int surface1 = l * w;
        int surface2 = w * h;
        int surface3 = h * l;

        return Math.Min(surface1, Math.Min(surface2, surface3));
    }

    public int CalculateTotalWrappingPaper(int l, int w, int h)
    {
        int surfaceArea = CalculateSurface(l, w, h);
        int smallestSide = CalculateSmallSurface(l, w, h);
        return surfaceArea + smallestSide;
    }
}