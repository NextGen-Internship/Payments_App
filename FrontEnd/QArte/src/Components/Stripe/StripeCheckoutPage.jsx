import React from 'react'
import CheckoutForm from './CheckoutForm'
import {Elements} from '@stripe/react-stripe-js';
import {loadStripe} from '@stripe/stripe-js';

// Make sure to call `loadStripe` outside of a component’s render to avoid
// recreating the `Stripe` object on every render.
const stripePromise = loadStripe('pk_test_51ObLNhJiciPf5qqfE5A8vgCGGYxyM61ipv972j1fnPvTcTRIrF1Sr8R508RCkJKcmDHal5dsEnpBKiHpCc8jWfbM00TQlvUPEo');

export default function App() {
  const options = {
    // passing the client secret obtained from the server
    clientSecret: '{{CLIENT_SECRET}}',
  };

  return (
    <Elements stripe={stripePromise} options={options}>
      <CheckoutForm />
    </Elements>
  );
};