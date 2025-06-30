import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  /**@type {import('@bcwdev/auth0provider-client').Identity} */
  identity: null,
  /** @type {import('./models/Account.js').Account} user info from the database*/
  account: null,
  /** @type {import('./models/Vault.js').Vault[]} The logged in users vaults only changes on login */
  accountVaults: [],

  /** @type {import('./models/Keep.js').Keep[]} user info from the database*/
  keeps: [],
  activeKeep: null,
  accountKeeps: [],

  /** @type {import('./models/Vault.js').Vault[]} This only gets set when on the profile page*/
  vaults: [],

  // Only used on the vault page
  activeVault: null,

  /** @type {import('./models/VaultKeep.js').VaultKeep[]} Only used on the vault page*/
  vaultKeeps: [],
})

