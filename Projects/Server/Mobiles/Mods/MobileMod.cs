/*************************************************************************
 * ModernUO                                                              *
 * Copyright 2019-2022 - ModernUO Development Team                       *
 * Email: hi@modernuo.com                                                *
 * File: MobileMod.cs                                                    *
 *                                                                       *
 * This program is free software: you can redistribute it and/or modify  *
 * it under the terms of the GNU General Public License as published by  *
 * the Free Software Foundation, either version 3 of the License, or     *
 * (at your option) any later version.                                   *
 *                                                                       *
 * You should have received a copy of the GNU General Public License     *
 * along with this program.  If not, see <http://www.gnu.org/licenses/>. *
 *************************************************************************/

using System;
using ModernUO.Serialization;

namespace Server;

[SerializationGenerator(0)]
public partial class MobileMod : IEquatable<MobileMod>
{
    [DirtyTrackingEntity]
    public Mobile Owner { get; set; }

    [SerializableField(0)]
    private string _name;

    public MobileMod(Mobile owner) => Owner = owner;

    public MobileMod(Mobile owner, string name)
    {
        Owner = owner;
        Name = name;
    }

    public bool Equals(MobileMod other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return _name == other._name && Equals(Owner, other.Owner);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        return obj.GetType() == GetType() && Equals((MobileMod)obj);
    }

    public override int GetHashCode() => HashCode.Combine(_name, Owner);
}
