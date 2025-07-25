export class VaultKeep {
  constructor(data) {
    this.id = data.id
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)
    this.keepId = data.keepId
    this.vaultId = data.vaultId
    this.creatorId = data.creatorId
    this.img = data.img
    this.name = data.name
    this.creator = data.creator
  }
}