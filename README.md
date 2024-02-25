# 3-Tier Solution for a Classroom Management System [![License](https://img.shields.io/github/license/KyriakosAd/3Tier-CRMS.svg)](https://github.com/KyriakosAd/3Tier-CRMS/blob/main/LICENSE) [![Size](https://img.shields.io/github/repo-size/KyriakosAd/3Tier-CRMS.svg)](https://github.com/KyriakosAd/3Tier-CRMS)
Used **C#** with **.NET** (Core) to create the **API** and divided the system into **3 tiers**:
 1) **DAL** - handles database communication with the **Microsoft SQL Server** through **EntityFramework**.
 2) **LOGIC** - handles the logic of the methods before they are sent to the frontend.
 3) **WEB_API** - forwards the web **API** methods to the frontend via **IIS Server**.

**Angular** was used for the frontend to communicate with the web **API** and to display the components.

<p align="middle">
  <img align="middle" src="https://github.com/KyriakosAd/3Tier-CRMS/assets/115529039/8004a7a8-eac5-4cef-a80b-8c6b8db5c2b4" width="29%" />
  <img align="middle" src="https://github.com/KyriakosAd/3Tier-CRMS/assets/115529039/2b7abd0e-a11a-4fb8-97d5-7b22037c1b85" width="70%" /> 
</p>

![frontend](https://github.com/KyriakosAd/3Tier-CRMS/assets/115529039/410072e6-8f95-4fdc-800c-1e3bb7c40914)
