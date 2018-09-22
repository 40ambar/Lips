var assert = require('assert');

function tokenize(str){
    return str.replace(/\(/g, ' ( ')
              .replace(/\)/g, ' ) ')
              .split(' ')
              .filter(k => k.length)
}

describe('Lisp klonu', function() {
    describe('Tokenizer', function() {
        it('tokenize simple expression (+ 1 2)', function() {
            assert.deepEqual(
                tokenize('(+ 1 2)'), [ '(', '+', '1', '2', ')' ]
            )
        })

        it('tokenize multidigit literal (+ 1231 2)', function() {
            assert.deepEqual(
                tokenize('(+ 1231 2)'), [ '(', '+', '1231', '2', ')' ]
            )
        })

        it('tokenize decimal literal (+ 2.45 456.45)', function() {
            assert.deepEqual(
                tokenize('(+ 2.45 456.45)'), [ '(', '+', '2.45', '456.45', ')' ]
            )
        })
    })

    describe('Paranthesizer', function() {
        it('paranthesize simpel exp (+ 1 2)', function() {

        })
    })

})