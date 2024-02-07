import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App.js";
import { GoogleOAuthProvider } from "@react-oauth/google";

ReactDOM.createRoot(document.getElementById("root")).render(
  <GoogleOAuthProvider clientId="724513848210-n7cf4h9qnd7rte8c6legmqfqc766qid1.apps.googleusercontent.com">
    <React.StrictMode>
      <App />
    </React.StrictMode>
  </GoogleOAuthProvider>
);
