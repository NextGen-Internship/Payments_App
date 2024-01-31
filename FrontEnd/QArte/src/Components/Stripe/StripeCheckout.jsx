import react, { Component } from 'react';

const StripeCheckout = () => 
{
    const handleSubmit = async (event) => {
        event.preventDefault();
    
        const successURL = 'http://localhost:5173/stripe-success';
        const cancelURL = 'http://localhost:5173/stripe-error';

        try {
          const response = await fetch('https://localhost:7191/api/Stripe/create-checkout-session', {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json',
            },
            body: JSON.stringify({
              successURL,
              cancelURL,
            }),
          });
    
          if (response.ok) {
            const responseData = await response.json();
            const redirectUrl = responseData.redirectUrl;

            console.log('Checkout session created successfully');

            window.location.href = redirectUrl;
          } else {

            console.error('Error creating checkout session');
          }
        } catch (error) {
          console.error('An error occurred while making the request', error);
        }
      };
    
      return (
        <div>
          <form onSubmit={handleSubmit}>
            <button type="submit">Checkout</button>
          </form>
        </div>
      );
}
export default StripeCheckout;