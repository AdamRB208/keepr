export class Profile {
  constructor(data) {
    this.id = data.id
    this.name = data.name
    this.picture = data.picture
    this.coverImg = data.coverImg
  }
}

export class Account extends Profile {
  /**
   * @typedef AccountData
   * @property {string} id
   * @property {string} email
   * @property {string} name
   * @property {string} picture
   * @property {string} coverImg
   * 
   * @param {AccountData} data
   */
  constructor(data) {
    super(data)
    this.email = data.email

  }
}
