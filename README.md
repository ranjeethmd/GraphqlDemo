# Graphql Demo on .NET 5

This repository contains demo code for GraphQL implementation in .NET Core.

[Mutations Example](docs/mutations.md)  
[Queries Example](docs/queries.md)

## TODO ::

- [x] Build basic Graphql application to perform
  - Queries
  - Mutations
  - Type Declarations
- [x] Enable REACT Relay.
- [x] Implement REACT front end with Apollo client.
- [x] Explore security.
  - Integrate REACT with Azure AD OIDC with Authroization code flow with PKCE.
  - Add access token support to Apollo client.
  - Add scope support to GraphQL server for Authoriazation
  - Implement code first Policy based Authorization on GraphQL type
- [x] Enable paging.
- [x] lazy loading.
  - npm install --save-dev jest
  - npm install --save-dev enzyme enzyme-adapter-react-16 enzyme-to-json
- [x] Explore ease of unit testing.
- [ ] Containarize application on K8s.
- [ ] Add subscription for real-time notifications:tada:

[^note]: .NET Core is open source and works seamlessly with Container and all the popular OS.
