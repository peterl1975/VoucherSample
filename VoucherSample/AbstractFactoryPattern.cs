using System;
namespace VoucherSample
{


    /// <summary>
    /// The 'AbstractFactory' abstract class
    /// </summary>

    abstract class RedemptionFactory
    {
        public abstract SetVoucher CreateVoucher();
        public abstract DeductVoucher DeleteVoucher();
    }

    /// <summary>
    /// The 'ConcreteFactory1' class
    /// </summary>

    class SingleRedemptionFactory : RedemptionFactory
    {
        public override SetVoucher CreateVoucher()
        {
            return new SingleVoucherCreation();
        }
        public override DeductVoucher DeleteVoucher()
        {
            return new SingleVoucherDeduction();
        }
    }

    /// <summary>
    /// The 'ConcreteFactory2' class
    /// </summary>

    class MultiRedemptionFactory : RedemptionFactory
    {
        public override SetVoucher CreateVoucher()
        {
            return new MultiRedemptionCreation();
        }
        public override DeductVoucher DeleteVoucher()
        {
            return new MultiRedemptionDeduction();
        }
    }
    class XRedemptionFactory : RedemptionFactory
    {
        public override SetVoucher CreateVoucher()
        {
            return new XRedemptionCreation();
        }
        public override DeductVoucher DeleteVoucher()
        {
            return new XRedemptionDeduction();
        }
    }
    /// <summary>
    /// The 'AbstractProductA' abstract class
    /// </summary>

    abstract class SetVoucher
    {
    }

    /// <summary>
    /// The 'AbstractProductB' abstract class
    /// </summary>

    abstract class DeductVoucher
    {
        public abstract string ActionToUse(SetVoucher h);
    }

    /// <summary>
    /// The 'ProductA1' class
    /// </summary>

    class SingleVoucherCreation : SetVoucher
    {
    }

    /// <summary>
    /// The 'ProductB1' class
    /// </summary>

    class SingleVoucherDeduction : DeductVoucher
    {
        public override string ActionToUse(SetVoucher h)
        {

            return "Deduct voucher for a single voucher";
        }
    }

    /// <summary>
    /// The 'ProductA2' class
    /// </summary>

    class MultiRedemptionCreation : SetVoucher
    {
    }
    class XRedemptionCreation : SetVoucher
    {
    }

    /// <summary>
    /// The 'ProductB2' class
    /// </summary>

    class MultiRedemptionDeduction : DeductVoucher
    {
        public override string ActionToUse(SetVoucher h)
        {
            return "Deduct voucher for a multi voucher";
        }
    }
    class XRedemptionDeduction : DeductVoucher
    {
        public override string ActionToUse(SetVoucher h)
        {
            return "Deduct voucher for a X voucher";
        }
    }

    /// <summary>
    /// The 'Client' class 
    /// </summary>

    class Voucher
    {
        private SetVoucher _setVoucher;
        private DeductVoucher _deductVoucher;

        // Constructor

        public Voucher(RedemptionFactory factory)
        {
            _deductVoucher = factory.DeleteVoucher();
            _setVoucher = factory.CreateVoucher();
        }

        public string Process()
        {
            return _deductVoucher.ActionToUse(_setVoucher);
        }
    }
}
