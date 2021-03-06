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
- [x] Explore ease of unit testing.
  - npm install --save-dev react-scripts@latest
  - npm install --save-dev jest@27.4.7
  - npm install --save-dev @testing-library/jest-dom@latest
  - npm install --save-dev @testing-library/react
- [ ] Containarize application on K8s.
- [ ] Add subscription for real-time notifications:tada:

[^note]: .NET Core is open source and works seamlessly with Container and all the popular OS.
