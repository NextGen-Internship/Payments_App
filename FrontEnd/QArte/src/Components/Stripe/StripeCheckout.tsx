import react, { Component } from 'react';
import Button from '@mui/material/Button';

const StripeCheckout = ({userID} : any) => 
{
    const handleSubmit = async (event:any) => {
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
              userID,
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
        <div style={{ display:'flex', alignItems:'center', justifyContent: 'center'}}>
          <form onSubmit={handleSubmit}>
            <Button
              type="submit"
              variant="contained"
              color="success" 
              size="large"
              style={{position:'fixed', bottom: '20px', left: '20px',fontSize: '20px', padding: '20px 30px'}}
            >
              Donate
            </Button>
          </form>
        </div>
      );
}
export default StripeCheckout;