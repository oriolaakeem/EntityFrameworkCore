﻿using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Blueshift.EntityFrameworkCore.MongoDB.Tests.TestDomain
{
    [BsonDiscriminator(Required = true, RootClass = true)]
    [BsonKnownTypes(
        typeof(DerivedType1),
        typeof(SubRootType1)
    )]
    public abstract class RootType : IEquatable<RootType>
    {
        [BsonId]
        public ObjectId Id { get; private set; }

        public string StringProperty { get; set; } = Guid.NewGuid().ToString(format: "D");

        public override int GetHashCode()
            => base.GetHashCode();

        public override bool Equals(object obj)
            => Equals(obj as RootType);

        public virtual bool Equals(RootType other)
            => Id.Equals(other?.Id) &&
                   string.Equals(StringProperty, other?.StringProperty);
    }
}