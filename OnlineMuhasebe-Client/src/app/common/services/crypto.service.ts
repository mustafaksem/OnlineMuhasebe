import { Injectable } from '@angular/core';
import * as CryptoTS from 'crypto-ts';

@Injectable({
  providedIn: 'root'
})
export class CyrptoService {

  constructor() { }

  encrypto(value: string): string {
    return CryptoTS.AES.encrypt(value, 'secret key 123').toString();
  }

  decrypto(value: string): string {
    const bytes = CryptoTS.AES.decrypt(value, 'secret key 123');
    return bytes.toString(CryptoTS.enc.Utf8);
  }
}
