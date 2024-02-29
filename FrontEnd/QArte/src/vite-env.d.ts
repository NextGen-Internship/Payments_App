/// <reference types="vite/client" />

interface ImportMetaEnv {
    readonly VITE_APP_TITLE: string
    readonly VITE_BASE_URL :string
    readonly VITE_LOGIN_WITH_GOOGLE_ENDPOINT:string
    readonly VITE_SINGIN_ENDPOINT:string
    readonly VITE_SIGNUP_ENDPOINT:string
    readonly VITE_GOOGLE_CLIENT_ID:string
    

  }
  
  interface ImportMeta {
    readonly env: ImportMetaEnv
  }