﻿// <copyright file="DefaultValueTests.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace ZenLib.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Numerics;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using static ZenLib.Tests.TestHelper;

    /// <summary>
    /// Tests creating default values.
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class DefaultValueTests
    {
        /// <summary>
        /// Test integer minus with constants.
        /// </summary>
        [TestMethod]
        public void TestDefaultValues1()
        {
            Assert.IsTrue(new ZenFunction<Option<bool>>(() => Option.Null<bool>()).Assert(v => v.Value() == false));
            Assert.IsTrue(new ZenFunction<Option<byte>>(() => Option.Null<byte>()).Assert(v => v.Value() == 0));
            Assert.IsTrue(new ZenFunction<Option<ZenLib.Char>>(() => Option.Null<ZenLib.Char>()).Assert(v => v.Value() == ZenLib.Char.MinValue));
            Assert.IsTrue(new ZenFunction<Option<short>>(() => Option.Null<short>()).Assert(v => v.Value() == 0));
            Assert.IsTrue(new ZenFunction<Option<ushort>>(() => Option.Null<ushort>()).Assert(v => v.Value() == 0));
            Assert.IsTrue(new ZenFunction<Option<int>>(() => Option.Null<int>()).Assert(v => v.Value() == 0));
            Assert.IsTrue(new ZenFunction<Option<uint>>(() => Option.Null<uint>()).Assert(v => v.Value() == 0));
            Assert.IsTrue(new ZenFunction<Option<long>>(() => Option.Null<long>()).Assert(v => v.Value() == 0));
            Assert.IsTrue(new ZenFunction<Option<ulong>>(() => Option.Null<ulong>()).Assert(v => v.Value() == 0));
            Assert.IsTrue(new ZenFunction<Option<BigInteger>>(() => Option.Null<BigInteger>()).Assert(v => v.Value() == new BigInteger(0)));
            Assert.IsTrue(new ZenFunction<Option<Real>>(() => Option.Null<Real>()).Assert(v => v.Value() == new Real(0)));
            Assert.IsTrue(new ZenFunction<Option<Seq<bool>>>(() => Option.Null<Seq<bool>>()).Assert(v => v.Value() == new Seq<bool>()));
            Assert.IsTrue(new ZenFunction<Option<FSeq<bool>>>(() => Option.Null<FSeq<bool>>()).Assert(v => v.Value().IsEmpty()));
            Assert.IsTrue(new ZenFunction<Option<FMap<bool, bool>>>(() => Option.Null<FMap<bool, bool>>()).Assert(v => v.Value().Get(true).IsSome() == false));
        }

        /// <summary>
        /// Test that default values are correct..
        /// </summary>
        [TestMethod]
        public void TestDefaultValues2()
        {
            CheckDefault<bool>(false);
            CheckDefault<byte>((byte)0);
            CheckDefault<ZenLib.Char>(ZenLib.Char.MinValue);
            CheckDefault<short>((short)0);
            CheckDefault<ushort>((ushort)0);
            CheckDefault<int>(0);
            CheckDefault<uint>(0U);
            CheckDefault<long>(0L);
            CheckDefault<ulong>(0UL);
            CheckDefault<Int1>(new Int1(0));
            CheckDefault<Int2>(new Int2(0));
            CheckDefault<UInt1>(new UInt1(0));
            CheckDefault<UInt2>(new UInt2(0));
            CheckDefault<string>(string.Empty);
            CheckDefault<BigInteger>(new BigInteger(0));
            CheckDefault<Real>(new Real(0));
            CheckDefault<Pair<int, int>>(new Pair<int, int> { Item1 = 0, Item2 = 0 });
            CheckDefault<Option<int>>(Option.None<int>());

            var o = ReflectionUtilities.GetDefaultValue<Object2>();
            Assert.AreEqual(o.Field1, 0);
            Assert.AreEqual(o.Field2, 0);

            var l = ReflectionUtilities.GetDefaultValue<FSeq<int>>();
            Assert.AreEqual(0, l.Count());

            var m = ReflectionUtilities.GetDefaultValue<Map<byte, byte>>();
            Assert.AreEqual(0, m.Count());
            var v = Option.Null<Map<byte, byte>>();

            var d = ReflectionUtilities.GetDefaultValue<FMap<int, int>>();
        }

        private void CheckDefault<T>(object o)
        {
            Assert.AreEqual(ReflectionUtilities.GetDefaultValue<T>(), o);
        }
    }
}