﻿using System.Threading;
using GovLib.Contracts;
using GovLib.ProPublica;

namespace GovLib.Tests.ProPublica.Congress.Bills
{
    public class BillByIDFixture : CongressFixture
    {
        public Bill BillByID { get; }

        public BillByIDFixture()
        {
            BillByID = Congress.Bills.GetBillByID(Chamber.House, "hr21");
        }
    }
}