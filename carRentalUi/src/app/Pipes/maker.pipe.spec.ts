import { MakerPipe } from './maker.pipe';

describe('MakerPipe', () => {
  it('create an instance', () => {
    const pipe = new MakerPipe();
    expect(pipe).toBeTruthy();
  });
});
