﻿using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Blueshift.EntityFrameworkCore.MongoDB.Tests.TestDomain
{
    public class ComplexRecord : IEquatable<ComplexRecord>
    {
        [BsonId]
        public ObjectId Id { get; private set; }

        public ComplexSubDocument ComplexSubDocument { get; set; } = new ComplexSubDocument();

        public override int GetHashCode()
            => base.GetHashCode();

        public override bool Equals(object obj)
            => Equals(obj as ComplexRecord);

        public bool Equals(ComplexRecord other)
            => Id.Equals(other?.Id) &&
               Equals(ComplexSubDocument, other?.ComplexSubDocument);
    }
}