﻿using FluentAssertions;
using NUnit.Framework;
using SolidPrinciples.Model;
using Ploeh.AutoFixture;
using SolidPrinciples.Utilities.Exceptions;

namespace SolidPrinciples
{
    [TestFixture]
    public class RestaurantTests
    {
        private Fixture fixture;

        [SetUp]
        public void SetUp()
        {
            fixture = new Fixture();
        }

        [Test]
        public void Should_execute_order_when_payment_is_with_contact_and_print_receipt()
        {
            var order = fixture.Build<Order>().Create();
            var fakePaymentDetails = fixture.Build<PaymentDetails>()
                .With(c => c.PaymentMethod, PaymentMethod.ContactCreditCard)
                .Create();
            var fakePrintReceipt = true;

            var restaurant = new Restaurant();
            restaurant.ExecuteOrder(order, fakePaymentDetails, fakePrintReceipt);
        }

        [Test]
        public void Should_execute_order_when_payment_is_with_contactless_and_print_receipt()
        {
            var orderItems = fixture.Build<OrderItem>()
                .With(c => c.Quantity, 1)
                .With(c => c.Price, 5)
                .With(c => c.Discount, 0)
                .CreateMany(3);
            var fakeOrder = fixture.Build<Order>()
                .With(c => c.Items, orderItems)
                .Create();

            var fakePaymentDetails = fixture.Build<PaymentDetails>()
                .With(c => c.PaymentMethod, PaymentMethod.ContactLessCreditCard)
                .Create();
            var fakePrintReceipt = true;

            var restaurant = new Restaurant();
            restaurant.ExecuteOrder(fakeOrder, fakePaymentDetails, fakePrintReceipt);
        }

        [Test]
        public void Should_throw_exception_when_order_amount_is_25_and_payment_is_with_contactless()
        {
            var orderItems = fixture.Build<OrderItem>()
                .With(c => c.Quantity, 1)
                .With(c => c.Price, 5)
                .With(c => c.Discount, 0)
                .CreateMany(5);

            var fakeOrder = fixture.Build<Order>()
                .With(c => c.Items, orderItems)
                .Create();
            var fakePaymentDetails = fixture.Build<PaymentDetails>()
                .With(c => c.PaymentMethod, PaymentMethod.ContactLessCreditCard)
                .Create();

            var fakePrintReceipt = true;

            var restaurant = new Restaurant();
            restaurant.Invoking(y => y.ExecuteOrder(fakeOrder, fakePaymentDetails, fakePrintReceipt))
                .ShouldThrow<UnAuthorizedContactLessPayment>()
                .WithMessage("Amount is too big");
        }

        [Test]
        public void Should_throw_NotValidPaymentException_when_Payment_Method_is_mobile()
        {
            var fakeOrder = fixture.Build<Order>()
                .Create();
            var fakePaymentDetails = fixture.Build<PaymentDetails>()
                .With(c => c.PaymentMethod, PaymentMethod.Mobile)
                .Create();
            var fakePrintReceipt = true;

            var restaurant = new Restaurant();
            restaurant.Invoking(y => y.ExecuteOrder(fakeOrder, fakePaymentDetails, fakePrintReceipt))
                .ShouldThrow<NotValidPaymentException>()
                .WithMessage("Can not charge customer");
        }

        [Test]
        public void Should_execute_order_when_Payment_with_contact_but_without_print_receipt()
        {
            var fakeOrder = fixture.Build<Order>().Create();
            var fakePaymentDetails = fixture.Build<PaymentDetails>()
                .With(c=>c.PaymentMethod, PaymentMethod.ContactCreditCard)
                .Create();
            var fakePrintReceipt = false;

            var restaurant = new Restaurant();
            restaurant.ExecuteOrder(fakeOrder, fakePaymentDetails, fakePrintReceipt);
        }

        [Test]
        public void Should_execute_order_when_Payment_with_contactless_but_without_print_receipt()
        {
            var orderItems = fixture.Build<OrderItem>()
                .With(c => c.Quantity, 1)
                .With(c => c.Price, 5)
                .With(c => c.Discount, 0)
                .CreateMany(3);
            var fakeOrder = fixture.Build<Order>()
                .With(c=>c.Items, orderItems)
                .Create();
            var fakePaymentDetails = fixture.Build<PaymentDetails>()
                .With(c => c.PaymentMethod, PaymentMethod.ContactLessCreditCard)
                .Create();
            var fakePrintReceipt = false;

            var restaurant = new Restaurant();
            restaurant.ExecuteOrder(fakeOrder, fakePaymentDetails, fakePrintReceipt);
        }
    }
}
