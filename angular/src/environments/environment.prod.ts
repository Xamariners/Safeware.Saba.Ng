import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:/',
  redirectUri: baseUrl,
  clientId: 'Ng_App',
  responseType: 'code',
  scope: 'offline_access Ng',
  requireHttps: true,
  impersonation: {
    tenantImpersonation: true,
    userImpersonation: true,
  }
};

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'Ng',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:',
      rootNamespace: 'Safeware.Saba.Ng',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
} as Environment;
