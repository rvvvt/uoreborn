/*************************************************************************
 * ModernUO                                                              *
 * Copyright (C) 2019-2022 - ModernUO Development Team                   *
 * Email: hi@modernuo.com                                                *
 * File: GumpTextEntryLimited.cs                                         *
 *                                                                       *
 * This program is free software: you can redistribute it and/or modify  *
 * it under the terms of the GNU General Public License as published by  *
 * the Free Software Foundation, either version 3 of the License, or     *
 * (at your option) any later version.                                   *
 *                                                                       *
 * You should have received a copy of the GNU General Public License     *
 * along with this program.  If not, see <http://www.gnu.org/licenses/>. *
 *************************************************************************/

using System.Buffers;
using Server.Collections;

namespace Server.Gumps;

public class GumpTextEntryLimited : GumpEntry
{
    public GumpTextEntryLimited(
        int x, int y, int width, int height, int hue, int entryID, string initialText, int size = 0
    )
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
        Hue = hue;
        EntryID = entryID;
        InitialText = initialText;
        Size = size;
    }

    public int X { get; set; }

    public int Y { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }

    public int Hue { get; set; }

    public int EntryID { get; set; }

    public string InitialText { get; set; }

    public int Size { get; set; }

#if NET7_SDK
    public override void AppendTo(ref SpanWriter writer, OrderedHashSet<string> strings, scoped ref int entries, scoped ref int switches)
#else
    public override void AppendTo(ref SpanWriter writer, OrderedHashSet<string> strings, ref int entries, ref int switches)
#endif
    {
        var textIndex = strings.GetOrAdd(InitialText ?? "");
        writer.WriteAscii($"{{ textentrylimited {X} {Y} {Width} {Height} {Hue} {EntryID} {textIndex} {Size} }}");
        entries++;
    }
}
