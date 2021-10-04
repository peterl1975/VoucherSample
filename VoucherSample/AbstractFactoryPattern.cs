using System;
namespace VoucherSample
{


    /// <summary>
    /// The 'AbstractFactory' abstract class
    /// </summary>

    abstract class RedemptionFactory
    {
        public abstract VoucherItem VoucherItem();
        public abstract DeductVoucher DeductVoucher();
    }

    /// <summary>
    /// The 'ConcreteFactory1' class
    /// </summary>

    class SingleRedemptionFactory : RedemptionFactory
    {
        public override VoucherItem VoucherItem()
        {
            return new SingleVoucherCreation();
        }
        public override DeductVoucher DeductVoucher()
        {
            return new SingleVoucherDeduction();
        }
    }

    /// <summary>
    /// The 'ConcreteFactory2' class
    /// </summary>

    class MultiRedemptionFactory : RedemptionFactory
    {
        public override VoucherItem VoucherItem()
        {
            return new MultiRedemptionCreation();
        }
        public override DeductVoucher DeductVoucher()
        {
            return new MultiRedemptionDeduction();
        }
    }
    class XRedemptionFactory : RedemptionFactory
    {
        public override VoucherItem VoucherItem()
        {
            return new XRedemptionCreation();
        }
        public override DeductVoucher DeductVoucher()
        {
            return new XRedemptionDeduction();
        }
    }
    /// <summary>
    /// The 'AbstractProductA' abstract class
    /// </summary>

    abstract class VoucherItem
    {
    }

    /// <summary>
    /// The 'AbstractProductB' abstract class
    /// </summary>

    abstract class DeductVoucher
    {
        public abstract string ActionToUse(VoucherItem h);
    }

    /// <summary>
    /// The 'ProductA1' class
    /// </summary>

    class SingleVoucherCreation : VoucherItem
    {
    }

    /// <summary>
    /// The 'ProductB1' class
    /// </summary>

    class SingleVoucherDeduction : DeductVoucher
    {
        public override string ActionToUse(VoucherItem h)
        {

            return "Deduct voucher for a single voucher";
        }
    }

    

    /// <summary>
    /// The 'ProductA2' class
    /// </summary>

    class MultiRedemptionCreation : VoucherItem
    {
    }
    class XRedemptionCreation : VoucherItem
    {
    }

    /// <summary>
    /// The 'ProductB2' class
    /// </summary>

    class MultiRedemptionDeduction : DeductVoucher
    {
        public override string ActionToUse(VoucherItem h)
        {
            return "Deduct voucher for a multi voucher";
        }
    }
    class XRedemptionDeduction : DeductVoucher
    {
        public override string ActionToUse(VoucherItem h)
        {
            return "Deduct voucher for a X voucher";
        }
    }

    /// <summary>
    /// The 'Client' class 
    /// </summary>

    class Voucher
    {
        private VoucherItem _voucher;
        private DeductVoucher _deductVoucher;

        // Constructor

        public Voucher(RedemptionFactory factory)
        {
            _deductVoucher = factory.DeductVoucher();
            _voucher = factory.VoucherItem();
        }

        public string ProcessDeduction()
        {
            return _deductVoucher.ActionToUse(_voucher);
        }
    }
}
