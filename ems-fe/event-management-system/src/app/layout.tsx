"use client";
import './globals.css';
import { MsalProvider } from "@azure/msal-react";
import { PublicClientApplication } from "@azure/msal-browser";
import  { msalConfig } from '../../authConfig';
import { ReactNode } from 'react';

const msalInstance = new PublicClientApplication(msalConfig);

const RootLayout = ({ children }: { children: ReactNode }) => {
  return (
    <MsalProvider instance={msalInstance}>
      <html lang="en">
        <body>{children}</body>
      </html>
    </MsalProvider>
  );
};

export default RootLayout;
